FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Aleff.Pizzaria.Api/Aleff.Pizzaria.Api.csproj", "Aleff.Pizzaria.Api/"]
RUN dotnet restore "Aleff.Pizzaria.Api/Aleff.Pizzaria.Api.csproj"
COPY . .
WORKDIR "/src/Aleff.Pizzaria.Api"
RUN dotnet build "Aleff.Pizzaria.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Aleff.Pizzaria.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Aleff.Pizzaria.Api.dll"]
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh