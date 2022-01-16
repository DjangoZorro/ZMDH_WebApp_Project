using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SignalRChat.Hubs;

namespace ZMDH_WebApp.Models
{
    public class Client : IdentityUser
    {
        public virtual ICollection<Condition> Conditions { get; set; }

        public ChatHub chatHub { get; set; }
    }
}