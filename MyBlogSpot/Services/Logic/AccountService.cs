using Microsoft.Extensions.Configuration;
using MyBlogSpot.Models;
using MyBlogSpot.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSpot.Services.Logic
{
    public class AccountService : IAccountService
    {
        public HttpClient httpClient;
        private IConfiguration config;

        public AccountService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public async Task Login(Account account)
        {
            var messageString = JsonConvert.SerializeObject(account);
            var contentData = new StringContent(messageString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{config.GetValue<string>("ApiRoot")}/Account/Login", contentData);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();
            }

        }
    }
}
