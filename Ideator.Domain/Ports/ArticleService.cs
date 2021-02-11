using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ArticlePublisher _eventPublisher;

        public ArticleService(
            IArticleRepository articleRepository,
            IAuthorRepository authorRepository,
            ArticlePublisher eventPublisher)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _eventPublisher = eventPublisher;
        }

        public ArticleId Create(AuthorId authorId, Title title, Content content)
        {
            var author = _authorRepository.Get(authorId);
            var article = _articleRepository.Save(author, title, content);

            article.ValidateEligibilityForPublication();

            _eventPublisher.PublishCreationOf(article);
            return article.Id;
        }

        public Article Get(ArticleId id)
        {
            var article = _articleRepository.Get(id);
            _eventPublisher.PublishRetrievalOf(article);
            return article;
        }
    }
}