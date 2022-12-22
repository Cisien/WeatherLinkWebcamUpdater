FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/runtime:7.0 AS base
ARG TARGETPLATFORM
ARG BUILDPLATFORM
WORKDIR /app

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG TARGETPLATFORM
WORKDIR /src
COPY WeatherLinkWebcamUpdater.csproj .
RUN dotnet restore WeatherLinkWebcamUpdater.csproj
COPY . .
RUN dotnet build WeatherLinkWebcamUpdater.csproj -c Release -o /app/build --no-restore
RUN if [ "$TARGETPLATFORM" = "linux/amd64" ]; then \
    RID=linux-x64 ; \
    elif [ "$TARGETPLATFORM" = "linux/arm64" ]; then \
    RID=linux-arm64 ; \
    elif [ "$TARGETPLATFORM" = "linux/arm/v7" ]; then \
    RID=linux-arm ; \
    fi \

FROM build AS publish
RUN dotnet publish WeatherLinkWebcamUpdater.csproj -c Release -r $RID -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherLinkWebcamUpdater.dll"]
