# Use the official .NET Core SDK image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarSelector.csproj", "./"]
RUN dotnet restore "./CarSelector.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "CarSelector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarSelector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarSelector.dll"]