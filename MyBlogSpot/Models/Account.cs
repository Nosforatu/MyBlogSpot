using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
