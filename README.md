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

**Unit Testing**

The following packages were added to support xunit.

```
dotnet add package xunit --version 2.4.1
dotnet add package Microsoft.NET.Test.Sdk --version 16.7.0
dotnet add package xunit.runner.visualstudio --version 2.4.3
dotnet add package Moq --version 4.14.5
```

Also, the csproj *PropertyGroup* section was updated to include the following. 

```xml
    <GenerateProgramFile>false</GenerateProgramFile>
```




### Add Two Example Migrations

```
dotnet ef migrations add PostgresSystem
dotnet ef migrations add PostgresApp
```


#  Run the migration

## Local


Set an environment variable

```shell
export POSTGRES_CONNECTION_STRING=Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword
```


```shell
dotnet ef database update
```

## Generate scripts

You can generate SQL scripts for existing database.

```
dotnet ef migrations script
```

## Remove a migration

dotnet ef migrations remove

    
# Docker 

## Postgres

Dokcer Postgres instructions

```shell
mkdir -p /Users/devtools/repositories/RDMS/PostgreSQL/datamount

docker run -p 5432:5432 -d \
    --name postgresdb \
    -e POSTGRES_USER=postgres \
    -e POSTGRES_PASSWORD=CHANGEME \
    -e PGDATA=/var/lib/postgresql/data/pgdata \
    -v /Users/devtools/repositories/RDMS/PostgreSQL/datamount:/var/lib/postgresql/data \
    postgres
```

### K8

```shell
kubectl apply -f cloud/k8/PostgresSQL
```

```shell
kubectl port-forward  postgres-statefulset-0 5432:5432
```




## Db Migration Setup on Kubernetes Kind

Following the instructions.

[https://kind.sigs.k8s.io/docs/user/local-registry/](https://kind.sigs.k8s.io/docs/user/local-registry/)



Push Images to Repository

```
docker tag dbmigration:latest localhost:5000/dbmigration:latest
docker push localhost:5000/dbmigration:latest
kubectl create deployment dbmigration --image=localhost:5000/dbmigration:latest
```


### DB Migration Build

From root directory 

```shell
docker build -t dbmigration .
```


### Run Docker

```shell
docker run -e POSTGRES_CONNECTION_STRING="Host=<host>;Database=postgres;Username=postgres;Password=CHANGEME" -i -t -a stdout -a stderr --name dbmigration-task dbmigration
```

Debug a long running container

```shell
docker exec -i -t 6f60441901dc bash
```


### Run K8 - Kind

If jobs exists

```
kubectl delete job dbmigration
````


```
kubectl apply -f cloud/dbMigration-job.yml
```

```
kubectl describe job dbmigration
```

```
kubectl get pods
```

```
kubectl logs  dbmigration-s4cd9
```

