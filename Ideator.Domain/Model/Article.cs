namespace Ideator.Domain.Model
{
    public sealed class Article
    {
        public Article(ArticleId id, Title title, Content content, Author author)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
        }

        public ArticleId Id { get; }
        public Title Title { get; }
        public Content Content { get; }
        public Author Author { get; }

        public void ValidateEligibilityForPublication()
        {
            VerifyForPlagiarism();
            ValidateTitleLength();
            ValidateContentLength();
            CheckPunctuation();
            CheckGrammar();
            CheckStyle();
            //TODO: these methods are just placeholders with empty implementation
        }

        private void CheckGrammar()
        {
        }

        private void CheckStyle()
        {
        }

        private void CheckPunctuation()
        {
        }

        private void VerifyForPlagiarism()
        {
        }

        private void ValidateContentLength()
        {
        }

        private void ValidateTitleLength()
        {
        }
    }
}