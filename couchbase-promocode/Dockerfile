FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["couchbase-promocode/couchbase-promocode.csproj", "couchbase-promocode/"]
RUN dotnet restore "couchbase-promocode/couchbase-promocode.csproj"
COPY . .
WORKDIR "/src/couchbase-promocode"
RUN dotnet build "couchbase-promocode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "couchbase-promocode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "couchbase-promocode.dll"]
