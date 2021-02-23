using Ideator.Domain.Model;

namespace Ideator.Domain.Ports
{
    public interface IArticleMessageSender
    {
        void SendMessageForCreated(Article article);
        void SendMessageForRetrieved(Article article);
    }
}