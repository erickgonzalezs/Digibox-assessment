#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Digibox.Api/Digibox.Api.csproj", "Digibox.Api/"]
RUN dotnet restore "Digibox.Api/Digibox.Api.csproj"
COPY . .
WORKDIR "/src/Digibox.Api"
RUN dotnet build "Digibox.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Digibox.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Digibox.Api.dll"]