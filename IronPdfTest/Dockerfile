FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Required by IronPdf Linux
RUN apt update && apt install -y apt-utils libc6 libc6-dev libgtk2.0-0 libnss3 libatk-bridge2.0-0 libx11-xcb1 libxcb-dri3-0 libdrm-common libgbm1 libasound2 libayatana-appindicator3-1 libxrender1 libfontconfig1 libxshmfence1

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IronPdfTest/IronPdfTest.csproj", "IronPdfTest/"]
RUN dotnet restore "IronPdfTest/IronPdfTest.csproj"
COPY . .
WORKDIR "/src/IronPdfTest"
RUN dotnet build "IronPdfTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IronPdfTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IronPdfTest.dll"]