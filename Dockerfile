FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["GICMicro/CRMApplication.csproj", "GICMicro/"]
RUN dotnet restore "GICMicro/CRMApplication.csproj"
COPY . .
WORKDIR "/src/GICMicro"
RUN dotnet build "CRMApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CRMApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CRMApplication.dll"]