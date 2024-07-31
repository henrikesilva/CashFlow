#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV Connection=""
ENV JwtExpiresMinutes=""
ENV JwtSigningKey=""
WORKDIR /src
COPY ["src/CashFlow.API/CashFlow.API.csproj", "src/CashFlow.API/"]
COPY ["src/CashFlow.Application/CashFlow.Application.csproj", "src/CashFlow.Application/"]
COPY ["src/CashFlow.Communication/CashFlow.Communication.csproj", "src/CashFlow.Communication/"]
COPY ["src/CashFlow.Domain/CashFlow.Domain.csproj", "src/CashFlow.Domain/"]
COPY ["src/CashFlow.Exception/CashFlow.Exception.csproj", "src/CashFlow.Exception/"]
COPY ["src/CashFlow.Infraestructure/CashFlow.Infraestructure.csproj", "src/CashFlow.Infraestructure/"]
RUN dotnet restore "./src/CashFlow.API/CashFlow.API.csproj"
COPY . .
WORKDIR "/src/src/CashFlow.API"
RUN dotnet build "./CashFlow.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CashFlow.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashFlow.API.dll"]