using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public interface IAuthorRepository
    {
        Author Get(AuthorId authorId);
    }
}