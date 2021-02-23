using Ideator.Domain.Model;

namespace Ideator.Application.Article
{
    public record CreateArticleRequest(
        Title Title,
        Content Content,
        AuthorId AuthorId);
}