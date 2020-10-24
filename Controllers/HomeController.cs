using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Win32.SafeHandles;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IActionResult Index()
        {
            var model = _articleRepository.GetAllArticles();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            var article = _articleRepository.GetArticleById(id);
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo!=null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder,uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Article newArticle = new Article()
                {
                    Title = model.Title,
                    Content = model.Content,
                    PhotoPath = uniqueFileName
                };

                _articleRepository.Insert(newArticle);
                return RedirectToAction(nameof(Details), new {id = newArticle.Id});
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article article = _articleRepository.GetArticleById(id);
            ArticleEditViewModel articleEditViewModel = new ArticleEditViewModel()
            {
                Id = id,
                Title = article.Title,
                Content = article.Content,
                ExistingPhotoPath = article.PhotoPath
            };

            return View(articleEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ArticleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Article article = _articleRepository.GetArticleById(model.Id);
                article.Title = model.Title;
                article.Content = model.Content;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null) 
                    {
                        var path = Path.Combine(_webHostEnvironment.WebRootPath,"images", model.ExistingPhotoPath);
                        System.IO.File.Delete(path);
                    }
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    article.PhotoPath = uniqueFileName;
                }

                Article updateArticle = _articleRepository.Update(article);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public HomeController(IArticleRepository articleRepository, IWebHostEnvironment webHostEnvironment)
        {
            _articleRepository = articleRepository;
            _webHostEnvironment = webHostEnvironment;
        }
    }
}