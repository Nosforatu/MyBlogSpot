using MyBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> ValidateUser(User user);

        public Task<User> CreateUser(User user);

        public Task<User> GetUser(string username, string password);


    }
}
