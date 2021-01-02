#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CreditcardApi/CreditcardApi.csproj", "CreditcardApi/"]
RUN dotnet restore "CreditcardApi/CreditcardApi.csproj"
COPY . .
WORKDIR "/src/CreditcardApi"
RUN dotnet build "CreditcardApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CreditcardApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditcardApi.dll"]