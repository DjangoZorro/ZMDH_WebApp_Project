using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZMDH_WebApp.Models;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public ICollection<Pedagoog> Pedagogen { get; set; }
        public ICollection<Client> Clienten { get; set; }
    }
}