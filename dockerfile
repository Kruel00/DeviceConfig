FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish DeviceConfigApi/DeviceConfigApi.csproj -c Release -o /app

FROM runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DeviceConfigApi.dll"]