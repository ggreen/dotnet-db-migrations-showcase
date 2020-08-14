using DbMigrations.Database.Util;
using dotnet_db_migrations_showcase.Database.SQL;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Moq;
using Xunit;

namespace dotnet_db_migrations_showcase.Test
{
    public class SqlDirectorTest
    {
        [Fact]
        public void constructSystem()
        {
             var builder = new Mock<MigrationBuilder>(MockBehavior.Strict, new string[] {"MockProvider"});
             OperationBuilder<SqlOperation> operationBuilder = null;
             
             builder.Setup(b => b.Sql(It.IsAny<string>(),false)).Returns(operationBuilder);
             
             //MockBehavior.Strict, new object[] {"Hello"}
             
             var resourceReader = new Mock<ResourceReader>();
             resourceReader.Setup(r => r.ReadSystemSql()).Returns("");
             
            var sqlDirector = new SqlDirector(resourceReader.Object);
            sqlDirector.ConstructSystem(builder.Object);

            resourceReader.Verify(r=> r.ReadSystemSql(),Times.Once());
            builder.Verify(b => b.Sql(It.IsAny<string>(),false), Times.Once());
        }
    }
}