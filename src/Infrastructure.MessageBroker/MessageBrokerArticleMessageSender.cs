using System;
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
            Console.WriteLine(articleCreatedMessage);
        }

        public void SendMessageForRetrieved(Article article)
        {
            // TODO: message broker integration implementation comes here

            var articleRetrievedMessage = new ArticleRetrievedMessage(article);
            Console.WriteLine(articleRetrievedMessage);
        }
    }
}