using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Models
{
    public class BlogPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        public DateTime DateInserted { get; set; } 
    }
}
