#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestAPI/TestAPI.csproj", "TestAPI/"]
COPY ["DTO_MyChampions/DTO_MyChampions.csproj", "DTO_MyChampions/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["MyChampions/API_MyChampions.csproj", "MyChampions/"]
COPY ["StubLib/StubLib.csproj", "StubLib/"]
RUN dotnet restore "TestAPI/TestAPI.csproj"
COPY . .
WORKDIR "/src/TestAPI"
RUN dotnet build "TestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAPI.dll"]