using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public interface IAuthorNotifier
    {
        void NotifyAboutCreationOf(Article article);
    }
}