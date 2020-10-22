using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;

namespace blog.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Article Article { get; set; }
        public string PageTile { get; set; }
    }
}
