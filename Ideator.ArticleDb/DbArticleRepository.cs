using System;
using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.ArticleDb
{
    public class DbArticleRepository : IArticleRepository
    {
        public Article Save(Author author, Title title, Content content)
        {
            // TODO: Database integration implementation comes here

            var entity = new ArticleDatabaseModel(author, title, content);
            return entity.ToDomain();
        }

        public Article Get(ArticleId id)
        {
            // TODO: Database integration implementation comes here

            var entity = new ArticleDatabaseModel(
                new Author(
                    new AuthorId(Guid.NewGuid()),
                    new PersonName("William Shakespeare")),
                new Title("Hexagonal Architecture"),
                new Content("Lorem ipsum"));

            return entity.ToDomain();
        }
    }
}