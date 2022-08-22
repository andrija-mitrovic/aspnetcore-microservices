#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGateways/Web.Bff.Shopping/OcelotApiGw.Web/OcelotApiGw.Web.csproj", "ApiGateways/Web.Bff.Shopping/OcelotApiGw.Web/"]
RUN dotnet restore "ApiGateways/Web.Bff.Shopping/OcelotApiGw.Web/OcelotApiGw.Web.csproj"
COPY . .
WORKDIR "/src/ApiGateways/Web.Bff.Shopping/OcelotApiGw.Web"
RUN dotnet build "OcelotApiGw.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotApiGw.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotApiGw.Web.dll"]