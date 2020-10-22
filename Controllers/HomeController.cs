using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public ViewResult Index()
        {
            var model = _articleRepository.GetAllArticles();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            var article = _articleRepository.GetArticle(id);
            if (article == null)
            {
                Response.StatusCode = 404;
                return View("ArticleNotFound", id);
            }
            homeDetailsViewModel.Article = article;
            homeDetailsViewModel.PageTile = "文章详情";
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                var insert = _articleRepository.Insert(article);
                return RedirectToAction("Details", new {id = article.Id});
            }

            return RedirectToAction("Index");
        }

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
    }
}