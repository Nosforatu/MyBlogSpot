using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlogSpot.Services.Interfaces;
using MyBlogSpot.Utilities;
using MyBlogSpot.ViewModels;

namespace MyBlogSpot.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginCredentials)
        {
            loginCredentials.Password = PasswordHelper.HashPassword(loginCredentials.Password);
            var result = await accountService.Login(new Models.Account()
            {
                Username = loginCredentials.Username,
                Password = loginCredentials.Password
            });

            if(result)
            {
                RedirectToAction("Index", "Home");
                
            }

            return View();    
        }

        public async Task<IActionResult> Create(AccountViewModel account)
        {
            if(ModelState.IsValid)
            {
                if(account.Passowrd != account.ConfirmPassword)
                {
                    return View();
                }

                account.Passowrd = PasswordHelper.HashPassword(account.Passowrd);
                var result = await accountService.Create(new Models.Account()
                {
                    Username = account.UserName,
                    Password = account.Passowrd
                });

                if (result)
                {
                    RedirectToAction("Login", "Account");

                }
            }
            

            return View();
        }
    }
}
