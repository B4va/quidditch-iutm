FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Quidditch-Server/Quidditch-Server/Quidditch-Server.csproj", "Quidditch-Server/"]
RUN dotnet restore "Quidditch-Server/Quidditch-Server.csproj"
COPY Quidditch-Server/Quidditch-Server Quidditch-Server/
WORKDIR "/src/Quidditch-Server"
RUN dotnet build "Quidditch-Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quidditch-Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quidditch-Server.dll"]
