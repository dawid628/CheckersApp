using CheckersApp.Server.Data;
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
        public MultiplayerHub(TableManager tableManager)
        {
            this.tableManager = tableManager;
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
    }
}
