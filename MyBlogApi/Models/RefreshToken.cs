using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Models
{
    public class RefreshToken
    {
        public string Username { get; set; }
        public DateTime Expiration { get; set; }
        public string TokenString { get; set; }
    }
}
