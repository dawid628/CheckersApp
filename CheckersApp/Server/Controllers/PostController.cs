using CheckersApp.Server.Data;
using CheckersApp.Server.Entities;
using CheckersApp.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheckersApp.Shared.Models;

namespace CheckersApp.Server.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly ApplicationDbContext dbConext;
        private readonly UserManager<ApplicationUser> userManager;
        public PostController(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
        {
            this.dbConext = _dbContext;
            this.userManager = _userManager;
        }

        [HttpGet("GetPosts")]
        public List<KeyValuePair<string, string>> GetPosts()
        {
            List<KeyValuePair<string, string>> posts = new();
            var articles = dbConext.Posts.OrderByDescending(r => r.Id);
            foreach (var article in articles)
            {
                posts.Add(new KeyValuePair<string, string>(article.Title, article.Body));
            }
            return posts;
        }

        [HttpGet("GetPostsData")]
        public List<KeyValuePair<int, string>> GetPostsData()
        {
            List<KeyValuePair<int, string>> posts = new();
            var articles = dbConext.Posts;
            string name;

            foreach (var article in articles)
            {
                name = userManager.FindByIdAsync(article.AuthorId).Result.UserName;
                posts.Add(new KeyValuePair<int, string>(article.Id, name));
            }
            return posts;
        }

        [HttpGet("GetPostsTitles")]
        public List<KeyValuePair<int, string>> GetPostsTitles()
        {
            List<KeyValuePair<int, string>> titles = new();
            var articles = dbConext.Posts;

            foreach (var article in articles)
            {
                titles.Add(new KeyValuePair<int, string>(article.Id, article.Title));
            }
            return titles;
        }

        [HttpGet("DeletePost/{id}")]
        public LocalRedirectResult DeletePost(int id)
        {
            var post = dbConext.Posts.Find(id);
            dbConext.Posts.Remove(post);

            dbConext.SaveChanges();
          
            return LocalRedirect("/");
        }

        [HttpPut("CreatePost")]
        public LocalRedirectResult CreatePost([FromBody] PostModel postmodel)
        {
            if(postmodel.Body != null && postmodel.Title != null) { 
            var post = new Post()
            {
                Title = postmodel.Title,
                Body = postmodel.Body,
                AuthorId = userManager.FindByNameAsync(postmodel.Username).Result.Id
            };

            dbConext.Posts.Add(post);
            dbConext.SaveChanges();
            }

            return LocalRedirect("/");
        }
    }
}
