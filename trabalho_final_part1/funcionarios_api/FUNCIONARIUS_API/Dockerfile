FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["./FUNCIONARIUS_API.Domain/FUNCIONARIUS_API.Domain.csproj", "./FUNCIONARIUS_API.Domain/"]
COPY . .
COPY ["./FUNCIONARIUS_API.Repository/FUNCIONARIUS_API.Repository.csproj", "./FUNCIONARIUS_API.Repository/"]
COPY . .
COPY ["./FUNCIONARIUS_API.WebApi/FUNCIONARIUS_API.WebApi.csproj", "./FUNCIONARIUS_API.WebApi/"]
RUN dotnet restore "./FUNCIONARIUS_API.WebApi/FUNCIONARIUS_API.WebApi.csproj"
COPY . .
WORKDIR "/src/FUNCIONARIUS_API.WebApi"
RUN dotnet build "./FUNCIONARIUS_API.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./FUNCIONARIUS_API.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FUNCIONARIUS_API.WebApi.dll"]
