using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Model;
using Microsoft.EntityFrameworkCore;

namespace blog.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}