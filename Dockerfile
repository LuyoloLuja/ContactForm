# Use the .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet build -c Release -o /app/build

# Publish the application to the /app/publish folder
RUN dotnet publish -c Release -o /app/publish

# Use the .NET 8 runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Ensure the data directory exists inside the container
RUN mkdir -p /app/data

# Set environment variable for SQLite in Docker
ENV SQLITE_DB_PATH="Data Source=/app/data/ContactFormDb.db"

# Make SQLite database storage persistent
VOLUME ["/app/data"]

# Ensure SQLite has correct permissions
RUN chmod -R 777 /app/data

# Expose the port the application will run on
EXPOSE 8080

# Define the entry point for the container
ENTRYPOINT ["dotnet", "ContactForm.dll"]
