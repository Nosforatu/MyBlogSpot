using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Models;
using MyBlogApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        // GET: api/<UserAccount>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAccount>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserAccount>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAccount>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAccount>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private readonly IUserService userService;

        public UserAccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(User account)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedUser = await userService.GetUser(account.Username, account.Password);

            if (selectedUser == null)
            {
                return Unauthorized();
            }

            account.Password = "";

            return account;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedUser = await userService.CreateUser(user);
            if (selectedUser == null)
            {
                return BadRequest();
            }

            return user;

        }

        [HttpGet]
        public ActionResult<string> Test()
        {
            return Ok();
        }
    }
}
