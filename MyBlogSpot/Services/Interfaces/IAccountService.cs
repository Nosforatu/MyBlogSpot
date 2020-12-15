using MyBlogSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.Services.Interfaces
{
    public interface IAccountService
    {
        Task Login(Account account);
    }
}
