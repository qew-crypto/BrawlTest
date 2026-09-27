FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY v59/ ./
RUN dotnet restore BSL.v59/BSL.v59.csproj
RUN dotnet publish BSL.v59/BSL.v59.csproj -c Release -o /publish --no-restore
RUN curl -fsSL \
    https://github.com/playit-cloud/playit-agent/releases/download/v1.0.10/playit-linux-amd64 \
    -o /playit && chmod 0755 /playit
RUN curl -fsSL \
    https://github.com/ekzhang/bore/releases/download/v0.6.0/bore-v0.6.0-x86_64-unknown-linux-musl.tar.gz \
    | tar -xz -C /tmp && mv /tmp/bore /bore && chmod 0755 /bore

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /opt/brawltest
COPY --from=build /publish/ /opt/brawltest/
COPY --from=build /playit /usr/local/bin/playit
COPY --from=build /bore /usr/local/bin/bore
COPY docker-entrypoint.sh /usr/local/bin/docker-entrypoint.sh
RUN chmod 0755 /usr/local/bin/docker-entrypoint.sh
ENV PORT=3000
ENV GAME_PORT=9339
EXPOSE 3000
# BotHost mounts the repository over /app at runtime, so keep the published
# application under /opt where the deployment mount cannot hide it.
ENTRYPOINT ["/usr/local/bin/docker-entrypoint.sh"]
