using CheckersApp.Server.Data;
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
        private readonly ApplicationDbContext dbContext;

        public ApiController(TableManager tableManager, ApplicationDbContext dbContext)
        {
            this.tableManager = tableManager;
            this.dbContext = dbContext;
        }

        [HttpGet("GetTables")]
        public IEnumerable<string> GetTables()
        {
            return tableManager.Tables.Where(n => n.Value < 2).Select(n => n.Key);
        }
    }
}
