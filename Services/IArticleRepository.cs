using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;

namespace blog.Services
{
    public interface IArticleRepository
    {
        Article GetArticleById(int id);

        // void Save(Model.Article updateArticle);
        IEnumerable<Article> GetAllArticles();
        Article Insert(Article article);
        Article Update(Article updateArticle);
        Article Delete(int id);
    }
}