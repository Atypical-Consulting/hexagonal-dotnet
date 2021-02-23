using System;
using Ideator.Domain.Model;

namespace Ideator.Application.Article
{
    public class ArticleIdResponse
    {
        private ArticleIdResponse(Guid id)
        {
            Id = id;
        }

        public ArticleIdResponse(ArticleId articleId)
            : this(articleId.Value)
        {
        }

        public Guid Id { get; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}";
        }
    }
}