# DB Migration for DotNET

Database migration is a pattern that supports changes for application data backing services. They handle concerns like data schema changes for an application. They are typically managed and executed as part of the microservice build's pipeline.

This project is an implementation using [DOTNET Microsoft Entity Framework](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).


# Setup

## Setup in VS CODE


```
dotnet new console
dotnet add Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.4
dotnet tool install --global dotnet-ef
```



### Add Two Example Migrations

```
dotnet ef migrations add PostgresSystem
dotnet ef migrations add PostgresApp
```


#  Run the migration


Set an environment variable

```shell
export POSTGRES_CONNECTION_STRING=Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword
```


```shell
dotnet ef database update
```

# Generate scripts

You can generate SQL scripts for existing database.

```
dotnet ef migrations script
```

## Remove a migration

dotnet ef migrations remove

# Unit Testing

The following packages were added to support xunit.

```
dotnet add package xunit --version 2.4.1
dotnet add package Microsoft.NET.Test.Sdk --version 16.7.0
dotnet add package xunit.runner.visualstudio --version 2.4.3
dotnet add package Moq --version 4.14.5
```

Note youd muist Update csproj the *PropertyGroup* section. Add the following

```xml
    <GenerateProgramFile>false</GenerateProgramFile>
```
    
# Docker 

From root directory 

```shell
docker build -t dbmigration .
```

```shell
docker run -e POSTGRES_CONNECTION_STRING="Host=<host>;Database=postgres;Username=postgres;Password=mysecretpassword" -i -t -a stdout -a stderr --name dbmigration-task dbmigration
```

Debug a long running container

```shell
docker exec -i -t 6f60441901dc bash
```
