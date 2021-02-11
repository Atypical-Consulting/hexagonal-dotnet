using System;
using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.Notifications
{
    public class AuthorMailNotifier : IAuthorNotifier
    {
        public void NotifyAboutCreationOf(Article article)
        {
            // TODO: Mail system integration implementation comes here

            var articleMailModel = new ArticleMailModel(article);
            Console.WriteLine(articleMailModel);
        }
    }
}