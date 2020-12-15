using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Models
{
    public class JwtAuthResult
    {
        public string TokenString { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
