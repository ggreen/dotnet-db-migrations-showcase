using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class PostgresContext : DbContext
    {
        private const string CONNECTION_STRING_ENV = "POSTGRES_CONNECTION_STRING";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string confiuration = Environment.GetEnvironmentVariable(CONNECTION_STRING_ENV);
            if(confiuration == null)
                throw new ArgumentException($"Missing environment variable: {CONNECTION_STRING_ENV}");

            options.UseNpgsql(confiuration);

        }
            
    }
}