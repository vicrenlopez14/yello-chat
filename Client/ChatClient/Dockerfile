FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Client/ChatClient/ChatClient.csproj", "ChatClient/"]
RUN dotnet restore "Client/ChatClient/ChatClient.csproj"
COPY . .
WORKDIR "/src/ChatClient"
RUN dotnet build "ChatClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatClient.dll"]
