
using DbMigrations.Database.Util;
using Xunit;

namespace DbMigrations.Test
{
    public class ResourceReaderTest
    {
        [Fact]
        public void readFile()
        {
           ResourceReader reader = new ResourceReader();
           var sql = reader.ReadResource("PostgresSystem.sql");

           Assert.Contains("USER",sql);
            
        }
        
    }
}