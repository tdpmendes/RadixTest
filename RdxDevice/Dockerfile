#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RdxDevice/RdxDevice.csproj", "RdxDevice/"]
RUN dotnet restore "RdxDevice/RdxDevice.csproj"
COPY . .
WORKDIR "/src/RdxDevice"
RUN dotnet build "RdxDevice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RdxDevice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RdxDevice.dll"]