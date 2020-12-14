using MyBlogSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.ViewModels
{
    public class BlogPrevViewModel : BaseViewModel
    {
        public List<BlogPost> blogPosts {get;set;}
        
    }
}
