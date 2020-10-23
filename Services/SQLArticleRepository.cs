using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Infrastructure;
using blog.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace blog.Services
{
    public class SqlArticleRepository:IArticleRepository
    {
        private readonly AppDbContext _context;

        public SqlArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.Find(id);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles;
        }

        public Article Insert(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article;
        }

        public Article Update(Article updateArticle)
        {
            var article = _context.Articles.Attach(updateArticle);
            article.State = EntityState.Modified;
            _context.SaveChanges();
            return updateArticle;
        }

        public Article Delete(int id)
        {
            Article article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Remove(article);
                _context.SaveChanges();
            }

            return article;
        }
    }
}
