#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pastelaria/Pastelaria.csproj", "Pastelaria/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["PastelProvider.Integration/PastelProvider.Integration.csproj", "PastelProvider.Integration/"]
RUN dotnet restore "Pastelaria/Pastelaria.csproj"
COPY . .
WORKDIR "/src/Pastelaria"
RUN dotnet build "Pastelaria.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pastelaria.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pastelaria.dll"]