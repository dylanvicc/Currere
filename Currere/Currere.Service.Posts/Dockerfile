FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Currere.Service.Posts/Currere.Service.Posts.csproj", "Currere.Service.Posts/"]
RUN dotnet restore "./Currere.Service.Posts/Currere.Service.Posts.csproj"
COPY . .
WORKDIR "/src/Currere.Service.Posts"
RUN dotnet build "./Currere.Service.Posts.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Currere.Service.Posts.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Currere.Service.Posts.dll"]