FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["./FDP.API/FDP.API.Domain/FDP.API.Domain.csproj", "./FDP.API/FDP.API.Domain/"]
COPY . .
COPY ["./FDP.API/FDP.API.Repository/FDP.API.Repository.csproj", "./FDP.API/FDP.API.Repository/"]
COPY . .
COPY ["./FDP.API/FDP.API.Service/FDP.API.Service.csproj", "./FDP.API/FDP.API.Service/"]
COPY . .

COPY ["./FDP.API/FDP.API.WebApi/FDP.API.WebApi.csproj", "./FDP.API/FDP.API.WebApi/"]
RUN dotnet restore "./FDP.API/FDP.API.WebApi/FDP.API.WebApi.csproj"
COPY . .
WORKDIR "/src/FDP.API/FDP.API.WebApi"
RUN dotnet build "./FDP.API.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./FDP.API.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FDP.API.WebApi.dll"]