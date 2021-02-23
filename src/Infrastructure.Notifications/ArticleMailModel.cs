using Ideator.Domain.Model;

namespace Ideator.Notifications
{
    public class ArticleMailModel
    {
        private const string SubjectTemplate = "You have successfully published: >>{0}<<";
        private const string ContentTemplate = "check if everything is correct: >>{0}<<";
        private readonly string _content;

        private readonly string _recipientId;
        private readonly string _subject;

        public ArticleMailModel(Article article)
        {
            _recipientId = article.Author.Name.Value;
            _subject = string.Format(SubjectTemplate, article.Title.Value);
            _content = string.Format(ContentTemplate, article.Content.Value);
        }

        public override string ToString()
        {
            return $"{nameof(_subject)}: {_subject}";
        }
    }
}