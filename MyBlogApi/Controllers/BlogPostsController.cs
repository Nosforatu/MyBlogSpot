using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogApi.Context;
using MyBlogApi.Models;
using MyBlogApi.Services.Interfaces;

namespace MyBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogPostsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            return await blogService.GetBlogPosts();
        }
        
        [HttpGet("BlogPostsPrev")]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPostsPrev()
        {
            return await blogService.GetBlogPostsPrev();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            try
            {
                var blog = await blogService.GetBlogPost(id);
                if (blog == null)
                    return NotFound();

                return blog;
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
        {
            var post = await blogService.GetBlogPost(id);
            
            //Exists
            if(post == null)
            {
                return NotFound();
            }

            //Check is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await blogService.UpdateBlogPost(blogPost);

                return Ok();
            } catch(Exception e)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPost blogPost)
        {
            blogPost.DateInserted = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await blogService.InsertBlogPost(blogPost);

            return CreatedAtAction("GetBlogPost", new { id = blogPost.BlogPostId }, blogPost);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogPost>> DeleteBlogPost(int id)
        {
            var blogPost = await blogService.GetBlogPost(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            await blogService.DeleteBlogPost(id);

            return blogPost;
        }

    }
}
