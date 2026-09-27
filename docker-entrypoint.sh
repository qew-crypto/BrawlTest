#!/bin/sh
set -eu

provider="${TUNNEL_PROVIDER:-bore}"
tunnel_pid=""

case "${provider}" in
    playit)
        if [ -z "${PLAYIT_SECRET:-}" ]; then
            echo "TUNNEL_PROVIDER=playit requires PLAYIT_SECRET." >&2
            exit 1
        fi
        echo "Starting playit TCP tunnel agent..."
        /usr/local/bin/playit --secret "${PLAYIT_SECRET}" --platform-docker &
        tunnel_pid=$!
        ;;
    bore)
        echo "Starting free bore TCP tunnel for 127.0.0.1:${GAME_PORT:-9339}..."
        if [ -n "${BORE_PORT:-}" ]; then
            /usr/local/bin/bore local "${GAME_PORT:-9339}" \
                --local-host 127.0.0.1 --to "${BORE_SERVER:-bore.pub}" \
                --port "${BORE_PORT}" &
        else
            /usr/local/bin/bore local "${GAME_PORT:-9339}" \
                --local-host 127.0.0.1 --to "${BORE_SERVER:-bore.pub}" &
        fi
        tunnel_pid=$!
        ;;
    none)
        echo "Starting without a public TCP tunnel."
        ;;
    *)
        echo "Unknown TUNNEL_PROVIDER: ${provider}" >&2
        exit 1
        ;;
esac

terminate() {
    kill "${server_pid:-}" ${tunnel_pid:+"${tunnel_pid}"} 2>/dev/null || true
}
trap terminate INT TERM EXIT

dotnet /opt/brawltest/BSL.v59.dll &
server_pid=$!
wait "${server_pid}"