FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ResourceServer/ResourceServer.Api/ResourceServer.Api.csproj", "ResourceServer/ResourceServer.Api/"]
COPY ["ResourceServer/ResourceServer.Infrastructure/ResourceServer.Infrastructure.csproj", "ResourceServer/ResourceServer.Infrastructure/"]
COPY ["ResourceServer/ResourceServer.Core/ResourceServer.Core.csproj", "ResourceServer/ResourceServer.Core/"]
RUN dotnet restore "ResourceServer/ResourceServer.Api/ResourceServer.Api.csproj"
COPY . .
WORKDIR "/src/ResourceServer/ResourceServer.Api"
RUN dotnet build "ResourceServer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResourceServer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceServer.Api.dll"]