#FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS base
FROM ghcr.io/yuchia-wei/otel-dotnet-auto-instrumentation:8.0-bookworm-slim AS base
USER app
WORKDIR /app

# rootless port (dotnet 8 default)
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /src
COPY ["EFCoreLab.WebApi/EFCoreLab.WebApi.csproj", "EFCoreLab.WebApi/"]
COPY ["EFCoreLab.CrossCutting.Observability/EFCoreLab.CrossCutting.Observability.csproj", "EFCoreLab.CrossCutting.Observability/"]
COPY ["EFCoreLab.Persistence.Repositories/EFCoreLab.Persistence.Repositories.csproj", "EFCoreLab.Persistence.Repositories/"]
COPY ["EFCoreLab.Persistence.Metadata.SampleDb/EFCoreLab.Persistence.Metadata.SampleDb.csproj", "EFCoreLab.Persistence.Metadata.SampleDb/"]
RUN dotnet restore "EFCore.Lab.sln"
COPY . .
WORKDIR "/src/EFCoreLab.WebApi"
RUN dotnet build "EFCoreLab.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFCoreLab.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCoreLab.WebApi.dll"]