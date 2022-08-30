#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGateways/Mobile.Bff.Shopping/Shopping.Aggregator.Mobile/Shopping.Aggregator.Mobile.csproj", "ApiGateways/Mobile.Bff.Shopping/Shopping.Aggregator.Mobile/"]
RUN dotnet restore "ApiGateways/Mobile.Bff.Shopping/Shopping.Aggregator.Mobile/Shopping.Aggregator.Mobile.csproj"
COPY . .
WORKDIR "/src/ApiGateways/Mobile.Bff.Shopping/Shopping.Aggregator.Mobile"
RUN dotnet build "Shopping.Aggregator.Mobile.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopping.Aggregator.Mobile.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Aggregator.Mobile.dll"]
