using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class PostgresSystem : Migration
    {
  

        private string sql = @"
        CREATE USER APPUSER WITH PASSWORD 'password';
        CREATE SCHEMA IF NOT EXISTS APP AUTHORIZATION APPUSER;
        ";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
