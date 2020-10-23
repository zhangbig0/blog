using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace blog.ViewModels
{
    public class ArticleCreateViewModel
    {
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题，它不能为空")]
        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile Photo { get; set; }
    }
}