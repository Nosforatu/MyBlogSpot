using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Pseudonym { get; set; }

        public string Password { get; set; }
    }
}
