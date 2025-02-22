#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Docker.API/Docker.API.csproj", "Docker.API/"]
COPY ["Docker.Infrastructure/Docker.Infrastructure.csproj", "Docker.Infrastructure/"]
COPY ["Docker.Domain/Docker.Domain.csproj", "Docker.Domain/"]
RUN dotnet restore "./Docker.API/Docker.API.csproj"
COPY . .
WORKDIR "/src/Docker.API"
RUN dotnet build "./Docker.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Docker.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "Docker.API.dll","--server.urls","http://*/5000"]