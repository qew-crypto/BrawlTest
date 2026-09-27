# MeshBrawl — BSL v59

BSL v59 private-server test deployment for BotHost.

## BotHost

- Enable **Use custom Dockerfile**.
- Leave the startup command empty so BotHost uses the Dockerfile `ENTRYPOINT`.
- Set the internal web-application port to `3000`; it must match `PORT`.
- Set `PUBLIC_HOST=MeshBrawl.bothost.tech`.
- Optional Telegram variables: `BOT_TOKEN` and `TELEGRAM_CHAT_ID`.

If the logs contain `No .NET SDKs were found` together with
`The application 'BSL.v59.dll' does not exist`, the deployment is bypassing
the Dockerfile or overriding its startup command. Re-enable **Use custom
Dockerfile**, clear the startup command, and rebuild the deployment.

The active server source is in `v59/`. Older v52 files are retained only as an archive and are not copied into the Docker image.

## Android client

The compatible client must be BSL v59 for `arm64-v8a`. Configure:

```text
redirectHost = MeshBrawl.bothost.tech
redirectPort = 3000
```

The v52 client is not compatible with this server.
