using Microsoft.EntityFrameworkCore;
using MyBlogApi.Context;
using MyBlogApi.Models;
using MyBlogApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Services.Logic
{
    public class UserService : IUserService
    {

        private readonly MyBlogPostContext dbContext;

        public UserService(MyBlogPostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
                return user;
            }catch
            {
                throw;
            }
            
        }

        public async Task<User> GetUser(string username, string password)
        {
            return await dbContext.Users
                .Where(w => w.Pseudonym == username && w.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateUser(User user)
        {
            var selectedUser = await dbContext.Users.Where(w => w.Pseudonym == user.Pseudonym && w.Password == user.Password).FirstOrDefaultAsync();
            return (selectedUser != null);
        }
    }
}
