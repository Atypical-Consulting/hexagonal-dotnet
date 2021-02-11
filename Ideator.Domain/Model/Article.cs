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
            Console.WriteLine("OK - Check grammar");
        }

        private void CheckStyle()
        {
            Console.WriteLine("OK - Check style");
        }

        private void CheckPunctuation()
        {
            Console.WriteLine("OK - Check punctuation");
        }

        private void VerifyForPlagiarism()
        {
            Console.WriteLine("OK - Check for plagiarism");
        }

        private void ValidateContentLength()
        {
            Console.WriteLine("OK - Validate content length");
        }

        private void ValidateTitleLength()
        {
            Console.WriteLine("OK - Validate title length");
        }
    }
}