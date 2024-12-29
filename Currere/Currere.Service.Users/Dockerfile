FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Currere.Services.Users/Currere.Services.Users.csproj", "Currere.Services.Users/"]
RUN dotnet restore "./Currere.Services.Users/Currere.Services.Users.csproj"
COPY . .
WORKDIR "/src/Currere.Services.Users"
RUN dotnet build "./Currere.Services.Users.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Currere.Services.Users.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Currere.Services.Users.dll"]