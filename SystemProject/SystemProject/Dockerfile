 FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
 WORKDIR /app
 EXPOSE 80
 FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
 WORKDIR /src
 COPY ["SystemProject.csproj", ""]
 RUN dotnet restore "./SystemProject.csproj"
 COPY . .
 WORKDIR "/src/."
 RUN dotnet build "SystemProject.csproj" -c Release -o /app/build
 FROM build AS publish
 RUN dotnet publish "SystemProject.csproj" -c Release -o /app/publish
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "SystemProject.dll"]
