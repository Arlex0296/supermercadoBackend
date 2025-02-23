# Etapa 1: Build (Compilaci�n)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY SupermercadoAPI.csproj ./ 
RUN dotnet restore

# Copiar el resto del c�digo y compilar la aplicaci�n
COPY . ./ 
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime (Ejecuci�n)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar los archivos compilados de la etapa de compilaci�n
COPY --from=build /out .

# Exponer el puerto en el que corre la aplicaci�n
EXPOSE 8080

# Comando para ejecutar la aplicaci�n
ENTRYPOINT ["dotnet", "SupermercadoAPI.dll"]
