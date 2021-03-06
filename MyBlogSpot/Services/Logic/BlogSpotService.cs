﻿using Microsoft.Extensions.Configuration;
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
    public class BlogSpotService : IBlogSpotService
    {
        public HttpClient httpClient;
        private IConfiguration config;

        public BlogSpotService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public async Task<int> DeleteBlogPost(int id)
        {

            HttpResponseMessage response = await httpClient.DeleteAsync($"{config.GetValue<string>("ApiRoot")}/BlogPosts/{id}");
            return (response.IsSuccessStatusCode) ? id : -1;
        }        

        public async Task<BlogPost> GetBlogPost(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{config.GetValue<string>("ApiRoot")}/BlogPosts/{id}");
            if(response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BlogPost>(jsonResponseString);
            }

            return null;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{config.GetValue<string>("ApiRoot")}/BlogPosts");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BlogPost>>(jsonResponseString);
            }

            return null;
        }

        public async Task<List<BlogPost>> GetBlogPreview()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{config.GetValue<string>("ApiRoot")}/BlogPosts/BlogPostsPrev");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BlogPost>>(jsonResponseString);
            }

            return null;
        }

        public async Task<BlogPost> InsertBlogPost(BlogPost post)
        {
            var messageString = JsonConvert.SerializeObject(post);
            var contentData = new StringContent(messageString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{config.GetValue<string>("ApiRoot")}/BlogPosts", contentData);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BlogPost>(jsonResponseString);
            }

            return null;
        }

        public async Task<BlogPost> UpdateBlogPost(BlogPost post)
        {
            var messageString = JsonConvert.SerializeObject(post);
            var contentData = new StringContent(messageString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"{config.GetValue<string>("ApiRoot")}/BlogPosts/{post.BlogPostId}", contentData);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BlogPost>(jsonResponseString);
            }

            return null;
        }
    }
}
