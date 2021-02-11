using System;
using Ideator.Application;
using Ideator.Application.Article;
using Ideator.Domain.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Ideator.CLI
{
    internal class Program
    {
        private static ServiceProvider _serviceProvider;
        private static ArticleFacade _articles;

        private static void Main(string[] args)
        {
            RegisterServices();
            Run();
            DisposeServices();

            Console.WriteLine();
            Console.WriteLine("Type enter to exit...");
            Console.ReadLine();
        }

        private static void Run()
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("  [R] Get an Article by Id");
            Console.WriteLine("  [C] Create an Article");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            var consoleKeyInfo = Console.ReadKey();

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.R:
                    GetArticleById();
                    break;
                case ConsoleKey.C:
                    CreateArticle();
                    break;
            }
        }

        private static void GetArticleById()
        {
            // we generate a random author id for the sake of simplicity
            var articleId = new ArticleId(Guid.NewGuid());
            Console.WriteLine("\n");

            var articleResponse = _articles.Get(articleId);

            Console.WriteLine(articleResponse);
        }

        private static void CreateArticle()
        {
            Console.WriteLine("\n");

            Console.Write("Title    : ");
            var title = Console.ReadLine()?.Trim();
            
            Console.Write("Content  : ");
            var content = Console.ReadLine()?.Trim();

            // we generate a random author id for the sake of simplicity
            var authorId = Guid.NewGuid();
            Console.Write($"Author ID: {authorId}");
            Console.WriteLine("\n");

            var createArticleRequest = new CreateArticleRequest(
                new Title(title),
                new Content(content),
                new AuthorId(authorId));
            
            var articleIdResponse = _articles.Create(createArticleRequest);

            Console.WriteLine(articleIdResponse);
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .ConfigureDomainServices()
                .BuildServiceProvider();
            
            _articles = _serviceProvider
                .GetRequiredService<ArticleFacade>();
        }

        private static void DisposeServices()
        {
            _serviceProvider?.Dispose();
        }
    }
}