using System.Collections.Generic;
using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.Domain
{
    public class ArticlePublisher
    {
        private readonly List<IAuthorNotifier> _articleAuthorNotifiers;
        private readonly IArticleMessageSender _messageSender;
        private readonly List<ISocialMediaPublisher> _socialMediaPublishers;

        public ArticlePublisher(
            IArticleMessageSender messageSender,
            List<ISocialMediaPublisher> socialMediaPublishers,
            List<IAuthorNotifier> articleAuthorNotifiers)
        {
            _messageSender = messageSender;
            _socialMediaPublishers = socialMediaPublishers;
            _articleAuthorNotifiers = articleAuthorNotifiers;
        }

        public void PublishCreationOf(Article article)
        {
            _messageSender.SendMessageForCreated(article);
            _socialMediaPublishers.ForEach(x => x.Publish(article));
            _articleAuthorNotifiers.ForEach(x => x.NotifyAboutCreationOf(article));
        }

        public void PublishRetrievalOf(Article article)
        {
            _messageSender.SendMessageForRetrieved(article);
        }
    }
}