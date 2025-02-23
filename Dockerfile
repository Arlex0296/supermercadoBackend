# Etapa 1: Build (Compilación)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY SupermercadoAPI.csproj ./ 
RUN dotnet restore

# Copiar el resto del código y compilar la aplicación
COPY . ./ 
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime (Ejecución)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar los archivos compilados de la etapa de compilación
COPY --from=build /out .

# Exponer el puerto en el que corre la aplicación
EXPOSE 8080

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "SupermercadoAPI.dll"]
