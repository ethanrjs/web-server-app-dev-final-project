# Web Server App Dev - Final Project
## Project: Game Catalog

A .NET 8 ASP.NET Core MVC web application for managing a video game catalog.
We chose this approach because we all have one hobby in common - Video Games.

## Prerequisites

Before running this application, you need to install:

1. Docker Desktop - Download free from [docker.com](https://www.docker.com/products/docker-desktop/)
   - After installation, make sure Docker Desktop is running (Whale icon in system tray)

2. Git to clone the repository

## Running the Application

### Using Docker

The easiest way to run this application is with Docker. This approach packages everything you need - the web server and the database - into containers that run identically on any machine,
automatically installing the prerequisites and whatnot. 

To start the application: `docker-compose up --build`

This command:
1. Builds the .NET application into a 'Docker image'
2. Pulls the SQL Server image from Microsoft's container registry
3. Starts both containers and connects them together

To access the application: `http://localhost:5050`

To stop the application:
- Press `Ctrl+C` in the terminal, or run:
```bash
docker-compose down
```

To stop and remove all data (including the database):
```bash
docker-compose down -v
```

### Running Without Docker (Alternative)

If you prefer to run without Docker, you'll need:
- .NET 8 SDK installed
- SQL Server installed locally and (or update the connection string to point to your database)

```bash
dotnet restore
dotnet run
```

## Why Docker?

We won't explain why you should use Docker -- but in our case: One of our developers, Ethan R., uses a MacBook Pro as his daily device, which cannot run SQL Server, a vital program for this course.

## SQL Server Credentials

When running the application in Docker, SQL Server is automatically configured with the following credentials:

- Username: `sa`
- Password: `YourStrong!Passw0rd`
- Server: `localhost` (port `1433` when connecting from outside Docker)
- Database: `GameCatalog`

These credentials are configured in `docker-compose.yml` and `appsettings.Development.json`. If you need to connect to the SQL Server database directly (e.g., using SQL Server Management Studio or Azure Data Studio), use these credentials. 