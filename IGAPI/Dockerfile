FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IGAPI.csproj", "."]
RUN dotnet restore "IGAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "IGAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IGAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir -p /certs
ENTRYPOINT ["dotnet", "IGAPI.dll"]