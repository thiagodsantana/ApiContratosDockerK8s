# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar tudo do projeto
COPY . ./

# Restaurar e publicar
RUN dotnet restore ApiContratosDockerK8s.csproj
RUN dotnet publish ApiContratosDockerK8s.csproj -c Release -o /app

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiContratosDockerK8s.dll"]
