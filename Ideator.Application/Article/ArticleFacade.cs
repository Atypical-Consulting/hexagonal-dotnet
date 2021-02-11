using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.Application.Article
{
    public class ArticleFacade
    {
        private readonly ArticleService _articleService;

        public ArticleFacade(ArticleService articleService)
        {
            _articleService = articleService;
        }

        public ArticleResponse Get(ArticleId articleId)
        {
            var article = _articleService.Get(articleId);
            
            return new ArticleResponse(article);
        }

        public ArticleIdResponse Create(CreateArticleRequest createArticleRequest)
        {
            var (title, content, authorId) = createArticleRequest;
            
            var articleId = _articleService.Create(authorId, title, content);
            
            return new ArticleIdResponse(articleId);
        }
    }
}