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
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IJWTService jwtService;

        public AccountController(IUserService userService, IJWTService jwtService)
        {
            this.userService = userService;
            this.jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedUser = await userService.GetUser(user.Pseudonym, user.Password);

            if(selectedUser == null)
            {
                return Unauthorized();
            }

            var token = jwtService.GenerateToken(user.Pseudonym, DateTime.Now);


            return Ok();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return Ok();
        }
    }
}
