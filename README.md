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

The Docker image includes the official playit.gg agent. To expose the game
server when the hosting platform only supports web applications:

1. Create a playit.gg agent and TCP tunnel.
2. Point the tunnel's local address to `127.0.0.1:9339`.
3. Add the agent secret to BotHost as `PLAYIT_SECRET`.
4. Rebuild the deployment.
5. Put the public hostname and port assigned by playit.gg in the APK.

If `PLAYIT_SECRET` is missing, the game server and health endpoint still start,
but the game port is not exposed through playit.

## Android client

The compatible client must be BSL v59 for `arm64-v8a`. Configure it with the
public address assigned by playit.gg:

```text
redirectHost = <public TCP tunnel host>
redirectPort = <public TCP tunnel port>
```

The v52 client is not compatible with this server.
