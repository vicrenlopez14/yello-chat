FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YelloWriter/YelloWriter.csproj", "YelloWriter/"]
RUN dotnet restore "YelloWriter/YelloWriter.csproj"
COPY . .
WORKDIR "/src/YelloWriter"
RUN dotnet build "YelloWriter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YelloWriter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YelloWriter.dll"]
