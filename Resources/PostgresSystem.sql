DO
$do$
BEGIN
   IF NOT EXISTS (SELECT * FROM  pg_catalog.pg_roles WHERE  upper(rolname) = 'APPUSER') THEN
      CREATE USER APPUSER WITH PASSWORD 'password';
   END IF;
END
$do$;

CREATE SCHEMA IF NOT EXISTS APP AUTHORIZATION APPUSER;

CREATE TABLE APP.Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
);


