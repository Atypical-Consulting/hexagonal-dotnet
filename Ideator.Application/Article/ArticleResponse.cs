using System;

namespace Ideator.Application.Article
{
    public class ArticleResponse
    {
        private ArticleResponse(Guid id, string title, string content, string authorName)
        {
            Id = id;
            Title = title;
            Content = content;
            AuthorName = authorName;
        }

        public ArticleResponse(Domain.Model.Article article)
            : this(article.Id.Value, article.Title.Value, article.Content.Value, article.Author.Name.Value)
        {
        }

        public Guid Id { get; }

        public string Title { get; }

        public string Content { get; }

        public string AuthorName { get; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Content)}: {Content}, {nameof(AuthorName)}: {AuthorName}";
        }
    }
}