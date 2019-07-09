FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80


FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["InternalService.csproj", "InternalService/"]
RUN dotnet restore "InternalService/InternalService.csproj"
COPY . ./InternalService
WORKDIR "/src/InternalService/"
RUN dotnet build "InternalService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InternalService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InternalService.dll"]
