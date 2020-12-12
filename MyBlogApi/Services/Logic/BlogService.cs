using Microsoft.EntityFrameworkCore;
using MyBlogApi.Context;
using MyBlogApi.Models;
using MyBlogApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Services.Logic
{
    public class BlogService : IBlogService
    {
        private readonly MyBlogPostContext dbContext;

        public BlogService(MyBlogPostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteBlogPost(int id)
        {
            var post = await dbContext.BlogPosts.Where(w => w.BlogPostId == id).FirstOrDefaultAsync();
            if(post != null)
            {
                dbContext.BlogPosts.Remove(post);
                await dbContext.SaveChangesAsync();
                return id;
            }

            return 0;
        }

        public async Task<BlogPost> GetBlogPost(int id)
        {
            return await dbContext.BlogPosts.Where(w => w.BlogPostId == id).FirstOrDefaultAsync();
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await dbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> InsertBlogPost(BlogPost post)
        {
            post.DateInserted = DateTime.Now;
            dbContext.BlogPosts.Add(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<BlogPost> UpdateBlogPost(BlogPost blogPost)
        {
            var post = await dbContext.BlogPosts.Where(w => w.BlogPostId == blogPost.BlogPostId).FirstOrDefaultAsync();
            if (post != null)
            {
                dbContext.BlogPosts.Update(post);
                await dbContext.SaveChangesAsync();
                return post;
            }

            return null;
        }
    }
}
