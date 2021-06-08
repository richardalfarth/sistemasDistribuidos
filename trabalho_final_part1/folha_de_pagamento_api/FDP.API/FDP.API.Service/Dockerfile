FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FDP.API/FDP.API.Service/FDP.API.Service.csproj", "FDP.API/FDP.API.Service/"]
RUN dotnet restore "FDP.API/FDP.API.Service/FDP.API.Service.csproj"
COPY . .
WORKDIR "/src/FDP.API/FDP.API.Service"
RUN dotnet build "FDP.API.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FDP.API.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FDP.API.Service.dll"]
