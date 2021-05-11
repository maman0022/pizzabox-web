FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PizzaBox.Client/PizzaBox.Client.csproj", "PizzaBox.Client/"]
RUN dotnet restore "PizzaBox.Client/PizzaBox.Client.csproj"
COPY . .
WORKDIR "/src/PizzaBox.Client"
RUN dotnet build "PizzaBox.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzaBox.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzaBox.Client.dll"]

CMD ASPNETCORE_URLS=https://*:$PORT  dotnet PizzaBox.Client.dll