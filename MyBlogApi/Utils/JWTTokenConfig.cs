using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Utils
{
    public class JWTTokenConfig
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public string Audiance { get; set; }

        public int TokenExperation { get; set; }
        public int RefreshExperation { get; set; }
    }
}
