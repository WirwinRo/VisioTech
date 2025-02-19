# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV db_connection_String="Data Source=192.168.1.211,1433;Initial Catalog=VisioTech;Persist Security Info=True;Password=123456T;User ID=Develop;Encrypt=False;TrustServerCertificate=True"

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["visiotech.api/visiotech.api.csproj", "visiotech.api/"]
COPY ["visiotech.application/visiotech.application.csproj", "visiotech.application/"]
COPY ["visiotech.infrastructure/visiotech.infrastructure.csproj", "visiotech.infrastructure/"]
COPY ["visiotech.domain/visiotech.domain.csproj", "visiotech.domain/"]
RUN dotnet restore "./visiotech.api/visiotech.api.csproj"
COPY . .
WORKDIR "/src/visiotech.api"
RUN dotnet build "./visiotech.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./visiotech.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "visiotech.api.dll"]