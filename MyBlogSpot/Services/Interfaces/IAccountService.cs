using MyBlogSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSpot.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Login(Account account);
        Task<bool> Create(Account account);
    }
}
