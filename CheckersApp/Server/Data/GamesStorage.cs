using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckersApp.Server.Data
{
    public class GamesStorage
    {
        public List<KeyValuePair<string, string>> games = new();
    }
}
