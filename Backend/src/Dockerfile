FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5007

ENV ASPNETCORE_URLS=http://+:5007

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Proto2.API/Proto2.API.csproj", "Proto2.API/"]
COPY ["Proto2.Application/Proto2.Application.csproj", "Proto2.Application/"]
COPY ["Proto2.Domain/Proto2.Domain.csproj", "Proto2.Domain/"]
COPY ["Proto2.Persistence/Proto2.Persistence.csproj", "Proto2.Persistence/"]
RUN dotnet restore "Proto2.API/Proto2.API.csproj"
COPY . .
WORKDIR "/src/Proto2.API"
RUN dotnet build "Proto2.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Proto2.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proto2.API.dll"]
