FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YelloChat/YelloChat.csproj", "YelloChat/"]
RUN dotnet restore "YelloChat/YelloChat.csproj"
COPY . .
WORKDIR "/src/YelloChat"
RUN dotnet build "YelloChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YelloChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YelloChat.dll"]
