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

    // public class Blog
    // {
    //     public int BlogId { get; set; }
    //     public string Url { get; set; }

    //     public List<Post> Posts { get; } = new List<Post>();
    // }

    // public class Post
    // {
    //     public int PostId { get; set; }
    //     public string Title { get; set; }
    //     public string Content { get; set; }

    //     public int BlogId { get; set; }
    //     public Blog Blog { get; set; }
    // }
}