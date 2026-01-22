# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG APP_UID=1000
ARG APP_GID=1000
# create group/user so we can own the files
RUN groupadd -g $APP_GID appgroup || true \
 && useradd -m -u $APP_UID -g $APP_GID app || true
WORKDIR /app
EXPOSE 5000
EXPOSE 5001


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Foodie.ApiGateway/Foodie.ApiGateway.csproj", "Foodie.ApiGateway/"]
RUN dotnet restore "./Foodie.ApiGateway/Foodie.ApiGateway.csproj"
COPY . .
WORKDIR "/src/Foodie.ApiGateway"
RUN dotnet build "./Foodie.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Foodie.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
# copy published files and set ownership to the runtime user
COPY --from=publish --chown=$APP_UID:$APP_GID /app/publish .
USER app
ENTRYPOINT ["dotnet", "Foodie.ApiGateway.dll"]