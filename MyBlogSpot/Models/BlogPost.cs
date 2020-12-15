using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.Models
{
    public class BlogPost
    {
        [Required]
        public int BlogPostId { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(200)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public string BlogEntry { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        public string Pseudonym { get; set; }
        
        public DateTime DateInserted { get; set; }
    }
}
