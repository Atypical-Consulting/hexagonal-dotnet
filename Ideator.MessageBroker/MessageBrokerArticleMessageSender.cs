using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.MessageBroker
{
    public class MessageBrokerArticleMessageSender : IArticleMessageSender
    {
        public void SendMessageForCreated(Article article)
        {
            // TODO: message broker integration implementation comes here

            var articleCreatedMessage = new ArticleCreatedMessage(article);
        }

        public void SendMessageForRetrieved(Article article)
        {
            // TODO: message broker integration implementation comes here

            var articleRetrievedMessage = new ArticleRetrievedMessage(article);
        }
    }
}