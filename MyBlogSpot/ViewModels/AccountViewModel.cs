using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Passowrd { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
