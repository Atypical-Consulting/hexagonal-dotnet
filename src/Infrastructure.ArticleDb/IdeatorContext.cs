using System;
using Ideator.ArticleDb.Configuration;
using Ideator.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Ideator.ArticleDb
{
    public sealed class IdeatorContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }

        public IdeatorContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .LogTo(
                    Console.WriteLine,
                    (eventId, logLevel) =>
                        logLevel >= LogLevel.Information ||
                        eventId == RelationalEventId.ConnectionOpened ||
                        eventId == RelationalEventId.ConnectionClosed)
                .EnableSensitiveDataLogging()
                .UseSqlite("Data Source=ideator.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new AuthorConfiguration())
                .ApplyConfiguration(new ArticleConfiguration())
                .Seed();
        }
    }
}