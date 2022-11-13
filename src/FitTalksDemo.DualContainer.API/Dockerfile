#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FitTalksDemo.DualContainer.API/FitTalksDemo.DualContainer.API.csproj", "FitTalksDemo.DualContainer.API/"]
COPY ["FitTalksDemo.DualContainer.Service/FitTalksDemo.DualContainer.Service.csproj", "FitTalksDemo.DualContainer.Service/"]
COPY ["FitTalksDemo.DualContainer.Entities/FitTalksDemo.DualContainer.Entities.csproj", "FitTalksDemo.DualContainer.Entities/"]
COPY ["FitTalksDemo.DualContainer.Common/FitTalksDemo.DualContainer.Common.csproj", "FitTalksDemo.DualContainer.Common/"]
COPY ["FitTalksDemo.DualContainer.Data/FitTalksDemo.DualContainer.Data.csproj", "FitTalksDemo.DualContainer.Data/"]
RUN dotnet restore "FitTalksDemo.DualContainer.API/FitTalksDemo.DualContainer.API.csproj"
COPY . .
WORKDIR "/src/FitTalksDemo.DualContainer.API"
RUN dotnet build "FitTalksDemo.DualContainer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitTalksDemo.DualContainer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitTalksDemo.DualContainer.API.dll"]