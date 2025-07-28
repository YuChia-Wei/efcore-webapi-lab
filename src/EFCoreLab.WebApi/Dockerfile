#FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS base
FROM ghcr.io/yuchia-wei/otel-dotnet-auto-instrumentation:8.0-bookworm-slim AS base
WORKDIR /app

# root port
EXPOSE 80
EXPOSE 443

# rootless port (dotnet 8 default)
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /src
COPY ["EFCore.Lab.Repository/EFCore.Lab.Repository.csproj", "EFCore.Lab.Repository/"]
COPY ["EFCore.Lab.WebApi/EFCore.Lab.WebApi.csproj", "EFCore.Lab.WebApi/"]
RUN dotnet restore "EFCore.Lab.WebApi.csproj"
COPY . .
WORKDIR "/src/EFCore.Lab.WebApi"
RUN dotnet build "EFCore.Lab.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFCore.Lab.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabWebApi.dll"]