#!/bin/sh
set -eu

if [ -z "${PLAYIT_SECRET:-}" ]; then
    echo "PLAYIT_SECRET is not set; starting without a public TCP tunnel."
    exec dotnet /opt/brawltest/BSL.v59.dll
fi

echo "Starting playit TCP tunnel agent..."
/usr/local/bin/playit --secret "${PLAYIT_SECRET}" --platform-docker &
playit_pid=$!

terminate() {
    kill "${server_pid:-}" "${playit_pid:-}" 2>/dev/null || true
}
trap terminate INT TERM EXIT

dotnet /opt/brawltest/BSL.v59.dll &
server_pid=$!
wait "${server_pid}"