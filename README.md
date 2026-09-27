# MeshBrawl — BSL v59

BSL v59 private-server test deployment for BotHost.

## BotHost

- Enable **Use custom Dockerfile**.
- Leave the startup command empty so BotHost uses the Dockerfile `ENTRYPOINT`.
- Set the internal web-application port to `3000`; it must match `PORT`.
- Keep `GAME_PORT=9339`.
- Optional Telegram variables: `BOT_TOKEN` and `TELEGRAM_CHAT_ID`.

Port `3000` serves a small HTTP health response for BotHost. The Brawl Stars
server listens internally on raw TCP port `9339`.

## Public TCP tunnel

The image starts the free public `bore.pub` TCP tunnel by default, with no
account or payment required. After deployment, find this line in the logs:

```text
listening at bore.pub:<public port>
```

The public port is assigned dynamically and can change after a restart. Set
`BORE_PORT` to request a specific public port, but availability is best-effort
on the shared public service. Set `TUNNEL_PROVIDER=none` to disable the tunnel.

The image also supports playit.gg. Set `TUNNEL_PROVIDER=playit` and provide
`PLAYIT_SECRET` to use it instead.

## Android client

The compatible client must be BSL v59 for `arm64-v8a`. Configure it with the
public address printed by the tunnel:

```text
redirectHost = <public TCP tunnel host>
redirectPort = <public TCP tunnel port>
```

The v52 client is not compatible with this server.
