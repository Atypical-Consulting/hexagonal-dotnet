using System.Collections.Generic;
using Ideator.Application.Article;
using Ideator.ArticleDb;
using Ideator.AuthorService;
using Ideator.Domain;
using Ideator.Domain.Ports;
using Ideator.MessageBroker;
using Ideator.Notifications;
using Ideator.SocialMedia;
using Microsoft.Extensions.DependencyInjection;

namespace Ideator.Application
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IArticleRepository, DbArticleRepository>()
                .AddScoped<IAuthorRepository, ExternalServiceClientAuthorRepository>()
                .AddScoped<IArticleMessageSender, MessageBrokerArticleMessageSender>()
                
                .AddScoped<TwitterClient>()
                .AddScoped<TwitterArticlePublisher>()
                .AddScoped(
                    provider => new List<ISocialMediaPublisher>
                    {
                        provider.GetService<TwitterArticlePublisher>()
                    })

                .AddScoped<AuthorMailNotifier>()
                .AddScoped<AuthorSmsNotifier>()
                .AddScoped(
                    provider => new List<IAuthorNotifier>
                    {
                        provider.GetService<AuthorMailNotifier>(),
                        provider.GetService<AuthorSmsNotifier>()
                    })

                .AddScoped<ArticlePublisher>()
                .AddScoped<ArticleService>()
                .AddScoped<ArticleFacade>();
        }
    }
}