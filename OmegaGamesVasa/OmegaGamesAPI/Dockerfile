FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY ./OmegaGamesAPI/*.csproj OmegaGamesAPI/
COPY ./DataAccess/*.csproj DataAccess/
COPY ./Common/*.csproj Common/

RUN dotnet restore ./OmegaGamesAPI/OmegaGamesAPI.csproj

COPY . ./
RUN dotnet publish ./OmegaGamesAPI -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "OmegaGamesAPI.dll"]