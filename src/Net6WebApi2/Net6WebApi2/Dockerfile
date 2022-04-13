#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Net6WebApi2/Net6WebApi2.csproj", "Net6WebApi2/"]
COPY ["Net6WebApi2.DalCommon/Net6WebApi2.DalCommon.csproj", "Net6WebApi2.DalCommon/"]
COPY ["Net6WebApi2.DalEfImpl/Net6WebApi2.DalEfImpl.csproj", "Net6WebApi2.DalEfImpl/"]
RUN dotnet restore "Net6WebApi2/Net6WebApi2.csproj"
COPY . .
WORKDIR "/src/Net6WebApi2"
RUN dotnet build "Net6WebApi2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net6WebApi2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net6WebApi2.dll"]
