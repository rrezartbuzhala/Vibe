#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Rrezart.Vibe.Host/Rrezart.Vibe.Host.csproj", "Rrezart.Vibe.Host/"]
COPY ["Rrezart.Vibe.Persistence/Rrezart.Vibe.Persistence.csproj", "Rrezart.Vibe.Persistence/"]
COPY ["Rrezart.Vibe.Application/Rrezart.Vibe.Application.csproj", "Rrezart.Vibe.Application/"]
COPY ["Rrezart.Vibe.Domain/Rrezart.Vibe.Domain.csproj", "Rrezart.Vibe.Domain/"]
RUN dotnet restore "Rrezart.Vibe.Host/Rrezart.Vibe.Host.csproj"
COPY . .
WORKDIR "/src/Rrezart.Vibe.Host"
RUN dotnet build "Rrezart.Vibe.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rrezart.Vibe.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rrezart.Vibe.Host.dll"]