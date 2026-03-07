FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files first for layer caching
COPY FuryTechs.DotCommerce.sln global.json Default.Build.props Directory.Packages.props ./
COPY src/FuryTechs.DotCommerce.Core/FuryTechs.DotCommerce.Core.csproj src/FuryTechs.DotCommerce.Core/
COPY src/FuryTechs.DotCommerce.WebAPI/FuryTechs.DotCommerce.WebAPI.csproj src/FuryTechs.DotCommerce.WebAPI/

RUN dotnet restore

# Copy remaining source and publish
COPY src/ src/
RUN dotnet publish src/FuryTechs.DotCommerce.WebAPI/FuryTechs.DotCommerce.WebAPI.csproj \
    -c Release \
    -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FuryTechs.DotCommerce.WebAPI.dll"]
