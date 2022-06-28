using CheckersApp.Server.Data;
using CheckersApp.Server.Models;
using CheckersApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckersApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly TableManager tableManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ApiController(TableManager tableManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.tableManager = tableManager;
            this.userManager = userManager;
            this.roleManager = roleManager;    
        }

        [HttpGet("GetTables")]
        public IEnumerable<string> GetTables()
        {
            return tableManager.Tables.Where(n => n.Value < 2).Select(n => n.Key);
            
        }

        [HttpGet("GetNames")]
        public List<KeyValuePair<string, string>> GetNames()
        {
            return tableManager.Names;

        }

        [HttpGet("GetScores")]
        public Dictionary<string, int> GetScores()
        {
            Dictionary<string, int> names = new();
            var users = userManager.Users.OrderByDescending(n => n.Score);
            foreach(var user in users)
            {
                names.Add(user.UserName, user.Score);
            }
            return names;
        }

        [HttpGet("GetUsers")]
        public Dictionary<string, string> GetUsers()
        {
            Dictionary<string, string> names = new();
            var users = userManager.Users;
           // ApplicationUser user = new();
            foreach (var u in users)
            {
               // result = userManager.IsInRoleAsync(u, "user").Result;
                if(userManager.IsInRoleAsync(u, "user").Result)
                {
                    names.Add(u.Id, u.UserName);
                }      
            }
            return names;
        }

        [HttpGet("GetModerators")]
        public Dictionary<string, string> GetModerators()
        {
            Dictionary<string, string> names = new();
            var users = userManager.Users;
            foreach (var u in users)
            {
                if (userManager.IsInRoleAsync(u, "moderator").Result)
                {
                    names.Add(u.Id, u.UserName);
                }
            }
            return names;
        }

        [HttpGet("DeletePermission/{id}")]
        public async Task<LocalRedirectResult> DeletePermission(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;

            await userManager.RemoveFromRoleAsync(user, "moderator");
            if (!(userManager.IsInRoleAsync(user, "user").Result))
            {
                await userManager.AddToRoleAsync(user, "user");
            }
            return LocalRedirect("/administration");
        }

        [HttpGet("AddPermission/{id}")]
        public async Task<LocalRedirectResult> AddPermission(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;

            await userManager.RemoveFromRoleAsync(user, "user");
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "moderator"); 
            }
            return LocalRedirect("/administration");
        }
    }
}
