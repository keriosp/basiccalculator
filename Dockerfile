FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BasicCalculatorCore.csproj", ""]
RUN dotnet restore "./BasicCalculatorCore.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BasicCalculatorCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BasicCalculatorCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BasicCalculatorCore.dll"]