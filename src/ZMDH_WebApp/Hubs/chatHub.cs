using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        // public async Task SendMessage(string user, string message)
        // {
        //     await Clients.All.SendAsync("ReceiveMessage", user, message);
        // }

        public Task SendMessageToGroup(string user,string groupName, string message)
        {
            return Clients.Group(groupName).SendAsync("Send", $"{user}: {message}");
        }

        public async Task AddToGroup(string user,string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{user} has joined the group {groupName}.");
            
        }

        public async Task RemoveFromGroup(string user,string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("Send", $"{user} has left the group {groupName}.");
        }

        public Task SendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }
    }
}