FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

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
COPY ["./aspnetapp.pfx", "."]
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Str0ngP@ssw0rd
ENTRYPOINT ["dotnet", "IGAPI.dll"]
