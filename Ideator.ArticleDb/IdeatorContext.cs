using Ideator.ArticleDb.Configuration;
using Ideator.Domain.Model;
using Microsoft.EntityFrameworkCore;

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
            options.UseSqlite("Data Source=ideator.db");
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