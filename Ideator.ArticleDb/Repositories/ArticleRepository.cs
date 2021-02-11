using System;
using System.Collections.Generic;
using System.Linq;
using Ideator.Domain.Model;
using Ideator.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Ideator.ArticleDb.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IdeatorContext _context;

        public ArticleRepository(IdeatorContext context)
        {
            _context = context;
        }

        public ArticleId GetNextIdentity()
        {
            return new (Guid.NewGuid());
        }

        public IEnumerable<Article> GetAll()
        {
            return _context
                .Articles
                .Include(article => article.Author)
                .ToList();
        }

        public Article GetById(ArticleId id)
        {
            var byId = _context.Articles.Find(id);
            
            _context
                .Entry(byId)
                .Reference(x => x.Author)
                .Load();
            
            return byId;
        }

        public Article Insert(AuthorId authorId, Title title, Content content)
        {
            var newArticleId = GetNextIdentity();

            var article = new Article(
                newArticleId,
                authorId,
                title,
                content);
            
            _context
                .Articles
                .Add(article)
                .Reference(x => x.Author)
                .Load();
            
            _context.SaveChanges();

            return article;
        }

        public void Delete(ArticleId id)
        {
            var article = _context.Articles.Find(id);
            
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public void Update(Article model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}