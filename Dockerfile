FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base 
USER app 
WORKDIR /app 
EXPOSE 8080 
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
ARG BUILD_CONFIGURATION=Release 
WORKDIR /src 
COPY ["Payam.Consumer/Payam.Consumer.csproj", "Payam.Consumer/"] 
RUN dotnet restore "./Payam.Consumer/Payam.Consumer.csproj" 
COPY . . 
WORKDIR "/src/Payam.Consumer" 
RUN dotnet build "./Payam.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build 
 
FROM build AS publish 
ARG BUILD_CONFIGURATION=Release 
RUN dotnet publish "./Payam.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false 
 
FROM base AS final 
WORKDIR /app 
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "Payam.Consumer.dll"]