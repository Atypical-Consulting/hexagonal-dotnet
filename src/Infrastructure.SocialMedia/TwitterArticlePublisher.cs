using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.SocialMedia
{
    public class TwitterArticlePublisher : ISocialMediaPublisher
    {
        private readonly TwitterClient _twitterClient;

        public TwitterArticlePublisher(TwitterClient twitterClient)
        {
            _twitterClient = twitterClient;
        }

        public void Publish(Article article)
        {
            var articleTweet = new ArticleTwitterModel(article);
            _twitterClient.Tweet(articleTweet);
        }
    }
}