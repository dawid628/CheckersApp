using CheckersApp.Server.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CheckersApp.Server.Data
{
    public class PlayersManager
    {
        public string tableId { get; set; }
        public string whitePlayer { get; set; }
        public string blackPlayer { get; set; }
    }
}
