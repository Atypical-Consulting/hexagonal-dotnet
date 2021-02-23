using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public interface ISocialMediaPublisher
    {
        void Publish(Article article);
    }
}