FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /MagicOnionSample

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a debug
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /MagicOnionSample
COPY --from=build-env /MagicOnionSample/build/out .
ENTRYPOINT ["dotnet", "Application.Server.dll"]