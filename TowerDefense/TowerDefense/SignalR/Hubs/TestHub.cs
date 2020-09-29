using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.SignalR.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendMessage(string x, string y, string unitType)
        {
            await Clients.All.SendAsync("ReceiveMessage", x, y, unitType);
        }
    }
}
