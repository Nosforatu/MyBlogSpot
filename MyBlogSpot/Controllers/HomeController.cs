using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlogSpot.Models;
using MyBlogSpot.Services.Interfaces;
using MyBlogSpot.ViewModels;

namespace MyBlogSpot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogSpotService blogService;

        public HomeController(ILogger<HomeController> logger, IBlogSpotService blogService)
        {
            _logger = logger;
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogPost> blogs = await blogService.GetBlogPreview();
            BlogPrevViewModel blogViewModel = new BlogPrevViewModel();
            blogViewModel.blogPosts = blogs;
            return View(blogViewModel);
        }

        public async Task<ViewResult> Details(int id)
        {
            BlogPost blogs = await blogService.GetBlogPost(id);
            BlogViewModel blogViewModel = new BlogViewModel();
            blogViewModel.post = blogs;
            return View(blogViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPost post)
        {
            //Validation
            if(ModelState.IsValid)
            {

                //if (string.IsNullOrEmpty(post.Subject))
                //    ModelState.AddModelError("Subject", "Please add subject");

            }

            await blogService.InsertBlogPost(post);
            return RedirectToAction("Index");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
