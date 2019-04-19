FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy NuGet.config
COPY NuGet.config ./
COPY config.json ./

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore --configfile NuGet.config

COPY config.json /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app

COPY --from=build-env /app/out .
COPY NuGet.config /app/out

ENTRYPOINT ["dotnet", "OmegaBot.dll"]