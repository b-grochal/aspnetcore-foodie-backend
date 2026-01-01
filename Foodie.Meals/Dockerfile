# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Foodie.Meals/Foodie.Meals.API.csproj", "Foodie.Meals/"]
COPY ["Foodie.Common.Api/Foodie.Common.Api.csproj", "Foodie.Common.Api/"]
COPY ["Foodie.Common.Application/Foodie.Common.Application.csproj", "Foodie.Common.Application/"]
COPY ["Foodie.Common.Domain/Foodie.Common.Domain.csproj", "Foodie.Common.Domain/"]
COPY ["Foodie.Common/Foodie.Common.csproj", "Foodie.Common/"]
COPY ["Foodie.Common.Infrastructure/Foodie.Common.Infrastructure.csproj", "Foodie.Common.Infrastructure/"]
COPY ["Foodie.Meals.Application/Foodie.Meals.Application.csproj", "Foodie.Meals.Application/"]
COPY ["Foodie.Meals.Domain/Foodie.Meals.Domain.csproj", "Foodie.Meals.Domain/"]
COPY ["Foodie.Meals.Infrastructure/Foodie.Meals.Infrastructure.csproj", "Foodie.Meals.Infrastructure/"]
RUN dotnet restore "./Foodie.Meals/Foodie.Meals.API.csproj"
COPY . .
WORKDIR "/src/Foodie.Meals"
RUN dotnet build "./Foodie.Meals.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Foodie.Meals.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY Foodie.Common.Api/Settings ./Settings
ENTRYPOINT ["dotnet", "Foodie.Meals.API.dll"]