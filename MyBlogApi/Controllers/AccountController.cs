using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Models;
using MyBlogApi.Services.Interfaces;

namespace MyBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(User account)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedUser = await userService.GetUser(account.Username, account.Password);

            if(selectedUser == null)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedUser = await userService.CreateUser(user);
            if (selectedUser == null)
            {
                return BadRequest();
            }

            return new JsonResult(user);

        }

        [HttpGet]
        public ActionResult Test()
        {
            return Ok();
        }
    }
}
