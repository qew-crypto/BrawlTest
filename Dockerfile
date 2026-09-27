FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY v59/ ./
RUN dotnet restore BSL.v59/BSL.v59.csproj
RUN dotnet publish BSL.v59/BSL.v59.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV PORT=9339
EXPOSE 9339
# BotHost may replace the container working directory with the repository
# checkout. Use an absolute path so the published assembly is always found.
ENTRYPOINT ["dotnet", "/app/BSL.v59.dll"]
