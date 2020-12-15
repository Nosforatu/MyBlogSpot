using MyBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Services.Interfaces
{
    public interface IJWTService 
    {
        JwtAuthResult GenerateToken(string userName, DateTime now);
    }
}
