# ===========================================
#  Etapa base: runtime de ASP.NET Core
# ===========================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5000

# ===========================================
#  Etapa de compilación: SDK .NET
# ===========================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos la solución principal
COPY ["Payment.sln", "."]

# Copiamos los proyectos
COPY ["Payment.Domain/Payment.Domain.csproj", "Payment.Domain/"]
COPY ["Payment.Application/Payment.Application.csproj", "Payment.Application/"]
COPY ["Payment.Infrastructure/Payment.Infrastructure.csproj", "Payment.Infrastructure/"]
COPY ["Payment.WebApi/Payment.WebApi.csproj", "Payment.WebApi/"]

# Restauramos dependencias solo para WebApi (restaurará también dependencias del resto de proyectos)
RUN dotnet restore "Payment.WebApi/Payment.WebApi.csproj"

# Copiamos todo el código fuente
COPY . .

# Compilamos el proyecto en modo Release
WORKDIR "/src/Payment.WebApi"
RUN dotnet build "Payment.WebApi.csproj" -c Release -o /app/build

# ===========================================
#  Etapa de publicación
# ===========================================
FROM build AS publish
RUN dotnet publish "Payment.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ===========================================
#  Etapa final: imagen ligera para producción
# ===========================================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configuración de inicio de la aplicación
ENTRYPOINT ["dotnet", "Payment.WebApi.dll"]
