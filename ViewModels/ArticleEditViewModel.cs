using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.ViewModels
{
    public class ArticleEditViewModel:ArticleCreateViewModel
    {
        public int Id { get; set; }

        public string ExistingPhotoPath { get; set; }   
    }
}
