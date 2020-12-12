using Microsoft.EntityFrameworkCore;
using MyBlogApi.Models;
namespace MyBlogApi.Context
{
    public class MyBlogPostContext : DbContext
    {
        public MyBlogPostContext(DbContextOptions<MyBlogPostContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasKey(c => new { c.BlogPostId });
        }
    }
}
