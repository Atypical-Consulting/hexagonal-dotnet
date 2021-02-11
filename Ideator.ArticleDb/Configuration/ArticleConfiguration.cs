using System;
using Ideator.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ideator.ArticleDb.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.ToTable("Article");

            builder
                .Property(article => article.Id)
                .HasConversion(
                    id => id.Value,
                    guid => new ArticleId(guid))
                .IsRequired();

            builder
                .Property(article => article.AuthorId)
                .HasConversion(
                    id => id.Value,
                    guid => new AuthorId(guid))
                .IsRequired();

            builder
                .Property(article => article.Title)
                .HasConversion(
                    title => title.Value,
                    s => new Title(s))
                .IsRequired();

            builder
                .Property(article => article.Content)
                .HasConversion(
                    content => content.Value,
                    s => new Content(s))
                .IsRequired();
            
            builder
                .Property(b => b.AuthorId)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}