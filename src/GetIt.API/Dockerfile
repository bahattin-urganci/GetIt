#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GetIt.API/GetIt.API.csproj", "src/GetIt.API/"]
COPY ["src/GetIt.Application/GetIt.Application.csproj", "src/GetIt.Application/"]
COPY ["src/GetIt.Data/GetIt.Data.csproj", "src/GetIt.Data/"]
COPY ["src/GetIt.Core/GetIt.Core.csproj", "src/GetIt.Core/"]
COPY ["src/GetIt.Domain/GetIt.Domain.csproj", "src/GetIt.Domain/"]
RUN dotnet restore "src/GetIt.API/GetIt.API.csproj"
COPY . .
WORKDIR "/src/src/GetIt.API"
RUN dotnet build "GetIt.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GetIt.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GetIt.API.dll"]