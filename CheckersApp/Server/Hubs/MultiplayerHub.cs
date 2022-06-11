using CheckersApp.Server.Data;
using CheckersApp.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckersApp.Server.Hubs
{
    public class MultiplayerHub : Hub
    {
        private readonly TableManager tableManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly List<PlayersManager> playersTable;
        public MultiplayerHub(TableManager tableManager, UserManager<ApplicationUser> userManager)
        {
            this.tableManager = tableManager;
            this.userManager = userManager;
            this.playersTable = new List<PlayersManager>();
        }

        public async Task Move(string tableId, int previousColumn, int previousRow, int newColumn, int newRow)
        {
            await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("Move", previousColumn, previousRow, newColumn, newRow);
        }
        public async Task Delete(string tableId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
            tableManager.Tables.Remove(tableId);
        }

        public async Task JoinTable(string tableId) 
        {
            if(tableManager.Tables.ContainsKey(tableId))
            {
                if(tableManager.Tables[tableId] < 2) 
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
                    await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("TableJoined");
                    tableManager.Tables[tableId]++;
                }
            }
            else 
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
                tableManager.Tables.Add(tableId, 1);
            }
        }

        // User's score functions
        public async Task UpdateScore(string username, bool isWinner)
        {
            var user = await userManager.FindByNameAsync(username);
            if (isWinner)
            {
                user.Score += 90;
            }
            if (!isWinner) 
            {
                if(user.Score > 90)
                {
                    user.Score -= 90;
                }
                else
                {
                    user.Score = 0;
                }
                
            }
            await userManager.UpdateAsync(user);
        }
        public async Task Message(string tableId, string playername, string context)
        {
            await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("NewMessage", playername, context);
        }

/*        public async Task AddWhitePlayer(string tableId, string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            var table = playersTable.FirstOrDefault(a => a.tableId == tableId);
            if (table != null)
            {
                table.whitePlayer = userName;
            }
            if (table == null)
            {
                PlayersManager man = new PlayersManager();
                man.tableId = tableId;
                man.whitePlayer = userName;
                playersTable.Add(man);
                await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("MamyTo");
            }

        }
        public async Task AddBlackPlayer(string tableId, string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            var table = playersTable.Find(a => a.tableId == tableId);
            if (table != null)
            {
                table.blackPlayer = userName;
            }
            if (table == null)
            {
                playersTable.Add(new PlayersManager
                {
                    tableId = tableId,
                    blackPlayer = userName,
                    whitePlayer = ""
                });
            }
        }*/
    }
}
