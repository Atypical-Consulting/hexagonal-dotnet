using System;
using Ideator.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Ideator.ArticleDb
{
    public static class SeedData
    {
        private static readonly Guid DefaultAuthorId =
            new("5F78060C-52EF-4190-A23A-B3F755A7DE28");
        
        private static readonly Guid SecondAuthorId =
            new("F4FA8B01-EF0E-463C-89AD-64DDCFD22AAF");
            
        public static void Seed(this ModelBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            
            builder
                .Entity<Author>()
                .HasData(
                    new Author(
                        new AuthorId(DefaultAuthorId),
                        new PersonName("Philippe Matray")),
                    new Author(
                        new AuthorId(SecondAuthorId),
                        new PersonName("Laure D'Este")));

            builder
                .Entity<Article>()
                .HasData(
                    new Article(
                        new ArticleId(Guid.NewGuid()),
                        new AuthorId(DefaultAuthorId),
                        new Title("Design Patterns"),
                        new Content("Lorem Ipsum")),
                    new Article(
                        new ArticleId(Guid.NewGuid()),
                        new AuthorId(SecondAuthorId),
                        new Title("Agile"),
                        new Content("Lorem Ipsum")));
        }
    }
}