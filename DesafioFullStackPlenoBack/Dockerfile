# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todos os projetos e restaurar dependências
COPY ["src/Desafio.Api/Desafio.Api.csproj", "Desafio.Api/"]
COPY ["src/Desafio.Application/Desafio.Application.csproj", "Desafio.Application/"]
COPY ["src/Desafio.Communication/Desafio.Communication.csproj", "Desafio.Communication/"]
COPY ["src/Desafio.Domain/Desafio.Domain.csproj", "Desafio.Domain/"]
COPY ["src/Desafio.Exceptions/Desafio.Exceptions.csproj", "Desafio.Exceptions/"]
COPY ["src/Desafio.Infrastructure/Desafio.Infrastructure.csproj", "Desafio.Infrastructure/"]

RUN dotnet restore "Desafio.Api/Desafio.Api.csproj"

# Copiar todo o código
COPY . .

# Build e publish
RUN dotnet publish "Desafio.Api/Desafio.Api.csproj" -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Desafio.Api.dll"]
