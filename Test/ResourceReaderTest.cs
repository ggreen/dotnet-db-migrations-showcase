
using DbMigrations.Database.Util;
using Xunit;

namespace DbMigrations.Test
{
    public class ResourceReaderTest
    {
        private readonly ResourceReader subject;
        public ResourceReaderTest()
        {
            subject = new ResourceReader();
        }

        [Fact]
        public void readFile()
        {
           var sql = subject.ReadResource("PostgresSystem.sql");

           Assert.Contains("USER",sql);
            
        }

        [Fact]
        public void testName()
        {
           Assert.Contains("USER",subject.ReadSystemSql());
        }
        
    }
}