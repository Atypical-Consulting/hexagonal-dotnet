using System;
using Ideator.Domain.Model;
using Ideator.Domain.Ports;

namespace Ideator.Notifications
{
    public class AuthorSmsNotifier : IAuthorNotifier
    {
        public void NotifyAboutCreationOf(Article article)
        {
            // TODO: SMS system integration implementation comes here
            var articleSmsModel = new ArticleSmsModel(article);
            Console.WriteLine(articleSmsModel);
        }
    }
}