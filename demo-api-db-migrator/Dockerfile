#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["demo-api-db-migrator.csproj", "."]
RUN dotnet restore "./demo-api-db-migrator.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "demo-api-db-migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo-api-db-migrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demo-api-db-migrator.dll"]