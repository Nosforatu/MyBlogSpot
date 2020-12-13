using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.ViewModels
{
    public class BlogViewModel
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Pseudonym  { get; set; }
        public string BlogEntry  { get; set; }
        public DateTime DateInserted { get; set; }
    }
}
