using System;
using DbMigrations.Database.Util;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_db_migrations_showcase.Database.SQL
{
    public class SqlDirector
    {
        private ResourceReader resourceReader;
        public SqlDirector() {
            resourceReader = new ResourceReader();
        } 

         public SqlDirector(ResourceReader resourceReader)
        {
            this.resourceReader = resourceReader;
        }

        internal void ConstructSystem(MigrationBuilder builder)
        {
            builder.Sql(resourceReader.ReadSystemSql());
        }
    }
}