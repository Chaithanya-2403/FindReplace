# Use a base image for .NET runtime on Linux
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the host to the container
COPY . .

# Grant execution permissions to the application (if needed)
RUN chmod +x ./ConsoleAppforFindReplace

# Ensure the data directory has the right permissions
RUN mkdir -p /app/data && chmod -R 777 /app/data

# Set the entry point for the application
ENTRYPOINT ["dotnet", "ConsoleAppforFindReplace.dll"]
