dotnet new console
dotnet add Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.4
dotnet tool install --global dotnet-ef

dotnet ef migrations add PostgresSystem
dotnet ef migrations add PostgresApp

dotnet ef database update





# Generate scripts

dotnet ef migrations script


# drop database
dotnet ef database drop



# Testing

dotnet add package xunit --version 2.4.1
dotnet add package Microsoft.NET.Test.Sdk --version 16.7.0
dotnet add package xunit.runner.visualstudio --version 2.4.3
dotnet add package Moq --version 4.14.5

Update csproj

    <GenerateProgramFile>false</GenerateProgramFile>
    </PropertyGroup>
