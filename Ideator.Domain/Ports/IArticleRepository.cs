using Ideator.Domain.Common;
using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public interface IArticleRepository
        : IRepository<ArticleId, Article>
    {
        Article Insert(AuthorId authorId, Title title, Content content);
    }
}