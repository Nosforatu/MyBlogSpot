using MyBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Services.Interfaces
{
    public interface IBlogService
    {
        public  Task<List<BlogPost>> GetBlogPosts();
        public  Task<List<BlogPost>> GetBlogPostsPrev();
        public  Task<BlogPost> GetBlogPost(int id);
        public  Task<int> DeleteBlogPost(int id);
        public Task<BlogPost> UpdateBlogPost(BlogPost post);
        public Task<BlogPost> InsertBlogPost(BlogPost post);
    }
}
