﻿FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "YelloServer/YelloServer.csproj"
# Build and publish a release
RUN dotnet publish  "YelloServer/YelloServer.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 5000 5001 80
WORKDIR /app
COPY --from=build-env /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet YelloServer.dll
ENTRYPOINT ["dotnet", "YelloServer.dll"]