FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EducationAndTest/EducationAndTest.csproj", "EducationAndTest/"]
RUN dotnet restore "EducationAndTest/EducationAndTest.csproj"
COPY . .
WORKDIR "/src/EducationAndTest"
RUN dotnet build "EducationAndTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EducationAndTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EducationAndTest.dll"]
