FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY v59/ ./
RUN dotnet restore BSL.v59/BSL.v59.csproj
RUN dotnet publish BSL.v59/BSL.v59.csproj -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /opt/brawltest
COPY --from=build /publish/ /opt/brawltest/
ENV PORT=3000
EXPOSE 3000
# BotHost mounts the repository over /app at runtime, so keep the published
# application under /opt where the deployment mount cannot hide it.
ENTRYPOINT ["dotnet", "/opt/brawltest/BSL.v59.dll"]
