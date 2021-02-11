using System.Collections.Generic;
using System.Linq;
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

        public Article Get(ArticleId id)
        {
            var article = _articleRepository.GetById(id);
            
            _eventPublisher.PublishRetrievalOf(article);
            return article;
        }

        public ArticleId Create(AuthorId authorId, Title title, Content content)
        {
            var article = _articleRepository.Insert(authorId, title, content);

            article.ValidateEligibilityForPublication();

            _eventPublisher.PublishCreationOf(article);
            return article.Id;
        }
    }
}