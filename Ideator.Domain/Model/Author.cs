using System.Collections.Generic;

namespace Ideator.Domain.Model
{
    public sealed class Author
    {
        public Author(AuthorId id, PersonName name)
        {
            Id = id;
            Name = name;
        }

        public AuthorId Id { get; }
        public PersonName Name { get; }
        
        public ICollection<Article> Articles { get; }
    }
}