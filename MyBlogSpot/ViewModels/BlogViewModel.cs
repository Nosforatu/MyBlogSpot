﻿using MyBlogSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.ViewModels
{
    public class BlogViewModel : BaseViewModel
    {
        public BlogPost post { get; set; }
    }
}
