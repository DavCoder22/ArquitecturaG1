# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy project files and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . .
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/out .

# Set the ASP.NET Core environment variable
ENV ASPNETCORE_ENVIRONMENT=Development

# Expose the port that the application will run on
EXPOSE 8080

# Command to run the application
ENTRYPOINT ["dotnet", "ArquitecturaG1.dll", "--urls", "http://0.0.0.0:8080"]
