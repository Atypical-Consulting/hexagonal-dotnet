using Ideator.Domain.Model;

namespace Ideator.SocialMedia
{
    public class ArticleTwitterModel
    {
        private const string TweetTemplate = "Check out the new article {0} by {1}";

        private readonly string _tweet;

        public ArticleTwitterModel(Article article)
        {
            var title = article.Title.Value;
            var twitterId = article.Author.Name.Value;

            _tweet = string.Format(TweetTemplate, title, twitterId);
        }

        public override string ToString()
        {
            return $"{nameof(_tweet)}: {_tweet}";
        }
    }
}