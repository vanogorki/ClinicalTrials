FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClinicalTrials.API/ClinicalTrials.API.csproj", "ClinicalTrials.API/"]
COPY ["ClinicalTrials.Application/ClinicalTrials.Application.csproj", "ClinicalTrials.Application/"]
COPY ["ClinicalTrials.Persistence/ClinicalTrials.Persistence.csproj", "ClinicalTrials.Persistence/"]
COPY ["ClinicalTrials.Domain/ClinicalTrials.Domain.csproj", "ClinicalTrials.Domain/"]
RUN dotnet restore "ClinicalTrials.API/ClinicalTrials.API.csproj"
COPY . .
WORKDIR "/src/ClinicalTrials.API"
RUN dotnet build "ClinicalTrials.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ClinicalTrials.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClinicalTrials.API.dll"]
