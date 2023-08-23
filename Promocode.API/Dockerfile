FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Promocode.API/Promocode.API.csproj", "Promocode.API/"]
RUN dotnet restore "Promocode.API/Promocode.API.csproj"
COPY . .
WORKDIR "/src/Promocode.API"
RUN dotnet build "Promocode.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Promocode.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Promocode.API.dll"]
