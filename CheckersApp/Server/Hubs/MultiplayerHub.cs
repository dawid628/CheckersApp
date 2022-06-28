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
        private GamesStorage storage;

        public MultiplayerHub(TableManager tableManager, UserManager<ApplicationUser> userManager, GamesStorage storage)
        {
            this.tableManager = tableManager;
            this.userManager = userManager;
            this.storage = storage;
    }

        public async Task Move(string tableId, int previousColumn, int previousRow, int newColumn, int newRow)
        {
            await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("Move", previousColumn, previousRow, newColumn, newRow);
        }
        public async Task Delete(string tableId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
            var game = storage.games.Find(k => k.Key == tableId);
            storage.games.Remove(game);
            tableManager.Tables.Remove(tableId);
            var name = tableManager.Names.Find(k => k.Key == tableId);
            tableManager.Names.Remove(name);       
        }

        public async Task JoinTable(string tableId, string playername) 
        {  
            if(tableManager.Tables.ContainsKey(tableId))
            {
                if(tableManager.Tables[tableId] < 2)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
                  
                    await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("TableJoined");
                    tableManager.Tables[tableId]++;
                    var game = storage.games.Find(r => r.Key == tableId);
                    if (game.Value == playername)
                    {
                        await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("SamePlayer");
                    }
                }
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
                tableManager.Tables.Add(tableId, 1);
                tableManager.Names.Add(new KeyValuePair<string, string>(tableId, playername));
                storage.games.Add(new KeyValuePair<string, string>(tableId, playername));
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
            await Clients.Group(tableId).SendAsync("Message", playername, context);
           
        }
    }
}
