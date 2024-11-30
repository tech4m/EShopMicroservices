#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Service/Ordering/Ordering.Api/Ordering.Api.csproj", "Service/Ordering/Ordering.Api/"]
COPY ["Service/Ordering/Ordering.Application/Ordering.Application.csproj", "Service/Ordering/Ordering.Application/"]
COPY ["BuildingBlocks/BuildingBlocks.Messaging/BuildingBlocks.Messaging.csproj", "BuildingBlocks/BuildingBlocks.Messaging/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Service/Ordering/Ordering.Domain/Ordering.Domain.csproj", "Service/Ordering/Ordering.Domain/"]
COPY ["Service/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Service/Ordering/Ordering.Infrastructure/"]
RUN dotnet restore "./Service/Ordering/Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/Service/Ordering/Ordering.Api"
RUN dotnet build "./Ordering.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ordering.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]