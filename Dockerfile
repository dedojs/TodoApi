FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copiando tudo
COPY . ./
# Restaurando depend�ncias
RUN dotnet restore
# Compilando e publicando vers�o de release
RUN dotnet publish -c Release -o out

# Utilizando imagem de execu��o
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
# Copiando da pasta /app/out de build-env para a pasta atual dessa imagem
COPY --from=build-env /app/out .
# Executando a aplica��o
ENTRYPOINT ["dotnet", "TodoApi.dll"]