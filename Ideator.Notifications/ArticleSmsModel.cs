using Ideator.Domain.Model;

namespace Ideator.Notifications
{
    public class ArticleSmsModel
    {
        private const string ContentTemplate =
            "Please check your email. We have sent you publication details of the article: >>{0}<<";

        private readonly string _recipientId;
        private readonly string _text;

        public ArticleSmsModel(Article article)
        {
            _recipientId = article.Author.Name.Value;
            _text = string.Format(ContentTemplate, article.Title.Value);
        }

        public override string ToString()
        {
            return $"{nameof(_text)}: {_text}";
        }
    }
}