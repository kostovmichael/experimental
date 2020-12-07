#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MvcSample/MvcSample.csproj", "MvcSample/"]
RUN dotnet restore "MvcSample/MvcSample.csproj"
COPY . .
WORKDIR "/src/MvcSample"
RUN dotnet build "MvcSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MvcSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MvcSample.dll"]