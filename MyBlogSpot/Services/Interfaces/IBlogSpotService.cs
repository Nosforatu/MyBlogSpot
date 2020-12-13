using MyBlogSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.Services.Interfaces
{
    public interface IBlogSpotService
    {
        public Task<BlogPost> GetBlogPost(int id);
        public Task<List<BlogPost>> GetBlogPosts();
        public Task<List<BlogPost>> GetBlogPreview();
        public Task<int> DeleteBlogPost(int id);
        public Task<BlogPost> InsertBlogPost(BlogPost post);
        public Task<BlogPost> UpdateBlogPost(BlogPost post);
    }
}
