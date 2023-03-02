#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RickAndMortyIntegration.WebAPI.csproj", "."]
COPY ["../RickAndMortyIntegration.Business/RickAndMortyIntegration.Business.csproj", "../RickAndMortyIntegration.Business/"]
COPY ["../RickAndMortyIntegration.Domain/RickAndMortyIntegration.Domain.csproj", "../RickAndMortyIntegration.Domain/"]
RUN dotnet restore "RickAndMortyIntegration.WebAPI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RickAndMortyIntegration.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RickAndMortyIntegration.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RickAndMortyIntegration.WebAPI.dll"]
