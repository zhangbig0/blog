using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;
using Microsoft.EntityFrameworkCore;

namespace blog.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "hello world",
                    Content = "asp.net core",
                });
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 2,
                    Title = "Test",
                    Content = "asp.net core Test",
                });
        }
    }
}
