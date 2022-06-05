using CheckersApp.Server.Data;
using CheckersApp.Server.Models;
using CheckersApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public ApiController(TableManager tableManager, UserManager<ApplicationUser> userManager)
        {
            this.tableManager = tableManager;
            this.userManager = userManager;
        }

        [HttpGet("GetTables")]
        public IEnumerable<string> GetTables()
        {
            return tableManager.Tables.Where(n => n.Value < 2).Select(n => n.Key);
        }

        [HttpGet("GetScores")]
        public Dictionary<string, int> GetScores()
        {
            Dictionary<string, int> names = new();
            var users = userManager.Users.OrderByDescending(n => n.Score).Take(10);
            foreach(var user in users)
            {
                names.Add(user.UserName, user.Score);
            }
            return names;
        }
    }
}
