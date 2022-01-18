using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZMDH_WebApp.Models;

namespace ZMDH_WebApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Pedagoog Pedagoog { get; set; }
        public Client Client { get; set; }
    }
}