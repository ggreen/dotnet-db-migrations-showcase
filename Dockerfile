FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet tool install --global dotnet-ef
RUN export PATH="$PATH:/root/.dotnet/tools"
COPY DbMigrations.csproj ./out/
ENV PATH $PATH:/root/.dotnet/tools

ENTRYPOINT ["dotnet", "ef", "database", "update"]