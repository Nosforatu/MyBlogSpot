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

namespace MyBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BlogPostsController : ControllerBase
    {
        private readonly MyBlogPostContext context;

        public BlogPostsController(MyBlogPostContext context)
        {
            this.context = context;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            return await context.BlogPosts.ToListAsync();
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            var blogPost = await context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }

        // PUT: api/BlogPosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
        {
            var post = context.BlogPosts.Where(w => w.BlogPostId == id).FirstOrDefault();
            
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
                context.Update(blogPost);

                await context.SaveChangesAsync();

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

            context.BlogPosts.Add(blogPost);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPost", new { id = blogPost.BlogPostId }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogPost>> DeleteBlogPost(int id)
        {
            var blogPost = await context.BlogPosts.Where(w => w.BlogPostId == id).FirstOrDefaultAsync();
            if (blogPost == null)
            {
                return NotFound();
            }

            context.BlogPosts.Remove(blogPost);
            await context.SaveChangesAsync();

            return blogPost;
        }

    }
}
