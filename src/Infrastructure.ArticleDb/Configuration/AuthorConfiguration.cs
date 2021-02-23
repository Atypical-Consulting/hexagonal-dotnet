using System;
using Ideator.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ideator.ArticleDb.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.ToTable("Author");

            builder
                .Property(author => author.Id)
                .HasConversion(
                    id => id.Value,
                    guid => new AuthorId(guid))
                .IsRequired();

            builder
                .Property(author => author.Name)
                .HasConversion(
                    personName => personName.Value,
                    s => new PersonName(s))
                .IsRequired();

            builder
                .HasMany(author => author.Articles)
                .WithOne(article => article.Author)
                .HasForeignKey(article => article.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}