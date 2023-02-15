#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyChampions/API_MyChampions.csproj", "MyChampions/"]
COPY ["DTO_MyChampions/DTO_MyChampions.csproj", "DTO_MyChampions/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["StubLib/StubLib.csproj", "StubLib/"]
RUN dotnet restore "MyChampions/API_MyChampions.csproj"
COPY . .
WORKDIR "/src/MyChampions"
RUN dotnet build "API_MyChampions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_MyChampions.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_MyChampions.dll"]