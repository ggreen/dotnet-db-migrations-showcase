using System.IO;
using System.Reflection;
using dotnet_db_migrations_showcase.Database.SQL;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class PostgresSystem : Migration
    {
        private SqlDirector  sql = new SqlDirector();


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            sql.ConstructSystem(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
