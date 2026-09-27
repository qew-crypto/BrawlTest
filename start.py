#!/usr/bin/env python3
"""BSL-V52 launcher for BotHost and similar Python hosting."""

from __future__ import annotations

import json
import os
import socket
import subprocess
import sys
import traceback
import urllib.parse
import urllib.request
from pathlib import Path

ROOT = Path(__file__).resolve().parent
HOST = "0.0.0.0"
PORT = int(os.getenv("PORT", "9339"))
BOT_TOKEN = os.getenv("BOT_TOKEN", "").strip()
CHAT_ID = os.getenv("TELEGRAM_CHAT_ID", "").strip()
PUBLIC_HOST = os.getenv("PUBLIC_HOST", "").strip()


def telegram(message: str) -> None:
    """Send a Telegram message if credentials are configured."""
    if not BOT_TOKEN or not CHAT_ID:
        print("Telegram: BOT_TOKEN or TELEGRAM_CHAT_ID is not configured")
        return
    data = urllib.parse.urlencode({"chat_id": CHAT_ID, "text": message}).encode()
    request = urllib.request.Request(
        f"https://api.telegram.org/bot{BOT_TOKEN}/sendMessage",
        data=data,
        method="POST",
    )
    with urllib.request.urlopen(request, timeout=20) as response:
        result = json.loads(response.read().decode("utf-8"))
    if not result.get("ok"):
        raise RuntimeError(f"Telegram API error: {result}")


def detect_public_ip() -> str:
    if PUBLIC_HOST:
        return PUBLIC_HOST
    for url in ("https://api.ipify.org", "https://ifconfig.me/ip"):
        try:
            with urllib.request.urlopen(url, timeout=10) as response:
                value = response.read().decode().strip()
            if value:
                return value
        except Exception:
            pass
    return "не определён"


def prepare_crypto() -> None:
    """Load _tweetnacl, compiling it locally when necessary."""
    crypto_dir = ROOT / "Heart" / "Crypto"
    sys.path.insert(0, str(crypto_dir))
    try:
        __import__("_tweetnacl")
        print("Crypto OK (_tweetnacl)")
        return
    except ImportError:
        pass

    try:
        __import__("nacl.bindings")
        print("Crypto OK (PyNaCl)")
        return
    except ImportError:
        print("PyNaCl not found; building _tweetnacl...")

    subprocess.run(
        [sys.executable, "setup.py", "build_ext", "--inplace"],
        cwd=crypto_dir,
        check=True,
    )
    __import__("_tweetnacl")
    print("Crypto built successfully")


def run_server() -> None:
    os.chdir(ROOT)  # Database paths in the original project are relative.
    prepare_crypto()
    from Heart.Connection import Connection

    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server.setsockopt(socket.IPPROTO_TCP, socket.TCP_NODELAY, True)
    server.bind((HOST, PORT))
    server.listen()

    public_host = detect_public_ip()
    status = (
        "✅ BSL-V52 запущен на BotHost\n"
        f"Адрес: {public_host}\n"
        f"Внутренний порт: {PORT}/TCP\n\n"
        "Настройки клиента:\n"
        f"redirectHost = {public_host}\n"
        f"redirectPort = {PORT}\n\n"
        "Если клиент не подключается, хостинг не пропускает внешний TCP-трафик."
    )
    print(status)
    try:
        telegram(status)
    except Exception as exc:
        print(f"Telegram notification failed: {exc}")

    while True:
        client, address = server.accept()
        print(f"New player: {address[0]}:{address[1]}")
        Connection(client, address).start()


def main() -> None:
    try:
        run_server()
    except Exception as exc:
        message = (
            "❌ BSL-V52 не запустился\n"
            f"Ошибка: {type(exc).__name__}: {exc}\n\n"
            f"{traceback.format_exc()[-2500:]}"
        )
        print(message, file=sys.stderr)
        try:
            telegram(message)
        except Exception as telegram_error:
            print(f"Telegram notification failed: {telegram_error}", file=sys.stderr)
        raise


if __name__ == "__main__":
    main()
