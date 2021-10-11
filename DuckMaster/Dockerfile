#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DuckMaster/DuckMaster.csproj", "DuckMaster/"]
RUN dotnet restore "DuckMaster/DuckMaster.csproj"
COPY . .
WORKDIR "/src/DuckMaster"
RUN dotnet build "DuckMaster.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DuckMaster.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DuckMaster.dll"]