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
RUN if [ "$TARGETPLATFORM" = "linux/amd64" ]; then \
RID=linux-x64 ; \
elif [ "$TARGETPLATFORM" = "linux/arm64" ]; then \
RID=linux-arm64 ; \
elif [ "$TARGETPLATFORM" = "linux/arm/v7" ]; then \
RID=linux-arm ; \
fi \
&& dotnet build WeatherLinkWebcamUpdater.csproj -c Release -o /app/build --no-restore \
&& dotnet publish WeatherLinkWebcamUpdater.csproj -c Release --no-build -r $RID -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WeatherLinkWebcamUpdater.dll"]
