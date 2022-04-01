FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YelloReader/YelloReader.csproj", "YelloReader/"]
RUN dotnet restore "YelloReader/YelloReader.csproj"
COPY . .
WORKDIR "/src/YelloReader"
RUN dotnet build "YelloReader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YelloReader.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YelloReader.dll"]
