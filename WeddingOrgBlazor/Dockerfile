#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WeddingOrgBlazor/WeddingOrgBlazor.csproj", "WeddingOrgBlazor/"]
COPY ["WeddingOrg/WeddingOrg.WebApi.csproj", "WeddingOrg/"]
COPY ["WeddingOrg.Infrastructure/WeddingOrg.Infrastructure.csproj", "WeddingOrg.Infrastructure/"]
COPY ["WeddingOrg.Application/WeddingOrg.Application.csproj", "WeddingOrg.Application/"]
COPY ["WeddingOrg.Domain/WeddingOrg.Domain.csproj", "WeddingOrg.Domain/"]
RUN dotnet restore "WeddingOrgBlazor/WeddingOrgBlazor.csproj"
COPY . .
WORKDIR "/src/WeddingOrgBlazor"
RUN dotnet build "WeddingOrgBlazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeddingOrgBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeddingOrgBlazor.dll"]