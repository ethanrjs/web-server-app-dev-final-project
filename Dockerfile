# This is the file to configure how Docker will build the application
# It will create a docker Image and respective container 

# Build stage --> This is the stage where the application is initialized
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy stage --> This is the stage where the project file is copied and 
# dependencies are restored
COPY ["web-server-app-dev-final.csproj", "."]
RUN dotnet restore

# Copy everything else and build
# This copies files such as the actual source code, db context, models, etc.
COPY . .    
RUN dotnet publish -c Release -o /app/publish

# Runtime stage --> This is the stage where the application is run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "web-server-app-dev-final.dll"]
