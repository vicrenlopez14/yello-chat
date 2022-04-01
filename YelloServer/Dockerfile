FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YelloServer/YelloServer.csproj", "YelloServer/"]
RUN dotnet restore "YelloServer/YelloServer.csproj"
COPY . .
WORKDIR "/src/YelloServer"
RUN dotnet build "YelloServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YelloServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YelloServer.dll"]
