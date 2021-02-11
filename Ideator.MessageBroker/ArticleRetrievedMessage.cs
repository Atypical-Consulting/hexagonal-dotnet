using System;
using Ideator.Domain.Model;

namespace Ideator.MessageBroker
{
    public class ArticleRetrievedMessage
    {
        private readonly Article _article;
        private readonly DateTime _sentAt;

        public ArticleRetrievedMessage(Article article)
        {
            _article = article;
            _sentAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Article {_article.Title.Value} retrieved";
        }
    }
}