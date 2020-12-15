using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string Email { get; set; }

        public string Pseudonym { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
