using System;
using Ideator.Domain.Model;

namespace Ideator.ArticleDb
{
    public class ArticleDatabaseModel
    {
        private readonly Guid _authorId;
        private readonly string _authorName;
        private readonly string _content;
        private readonly DateTime _createdAt;
        private readonly Guid _id;
        private readonly string _title;
        private readonly long _version;

        public ArticleDatabaseModel(Author author, Title title, Content content)
        {
            _id = Guid.NewGuid();
            _version = 0;
            _createdAt = DateTime.UtcNow;
            _authorId = author.Id.Value;
            _authorName = author.Name.Value;
            _title = title.Value;
            _content = content.Value;
        }

        public override string ToString()
        {
            return $"{nameof(_title)}: {_title}";
        }

        public Article ToDomain()
        {
            return new(
                new ArticleId(_id),
                new Title(_title),
                new Content(_content),
                new Author(
                    new AuthorId(_authorId),
                    new PersonName(_authorName)));
        }
    }
}