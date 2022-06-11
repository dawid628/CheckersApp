using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckersApp.Client.Data
{
    public class Message
    {
        public string player { get; set; }
        public string context { get; set; }
        public Message(string player, string context)
        {
            this.player = player;
            this.context = context;
        }
    }
}
