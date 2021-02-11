using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public interface IArticleRepository
    {
        Article Save(Author author, Title title, Content content);
        Article Get(ArticleId id);
    }
}