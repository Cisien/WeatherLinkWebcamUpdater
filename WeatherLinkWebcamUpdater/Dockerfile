FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY WeatherLinkWebcamUpdater.csproj .
RUN dotnet restore WeatherLinkWebcamUpdater.csproj
COPY . .
RUN dotnet build WeatherLinkWebcamUpdater.csproj -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish WeatherLinkWebcamUpdater.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherLinkWebcamUpdater.dll"]