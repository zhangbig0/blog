using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;

namespace blog.Services
{
    public class MockArticleRepository:IArticleRepository
    {
        private readonly List<Article> _articles;

        public MockArticleRepository()
        {
            _articles = new List<Article>()
            {
                new Article() {Id = 1, Title = " Hello World", Content = "Test1"},
                new Article() {Id = 2, Title = "Welcome", Content = "Good Job"},
            };
        }

        public Article GetArticleById(int id)
        {
            return _articles.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articles;
        }

        public Article Insert(Article article)
        {
            article.Id = _articles.Max(s => s.Id) + 1;
            _articles.Add(article);
            return article;
        }

        public Article Update(Article updateArticle)
        {
            Article article = _articles.FirstOrDefault(x => x.Id == updateArticle.Id);
            if (article!=null)
            {
                article.Title = updateArticle.Title;
                article.Content = updateArticle.Content;
            }

            return article;
        }

        public Article Delete(int id)
        {
            Article article = _articles.FirstOrDefault(x => x.Id == id);
            if (article!=null)
            {
                _articles.Remove(article);
            }
            return article;
        }
    }
}