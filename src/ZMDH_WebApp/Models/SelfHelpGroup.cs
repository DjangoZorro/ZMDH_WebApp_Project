using System.Collections.Generic;
using SignalRChat.Hubs;

namespace ZMDH_WebApp.Models
{
    public class SelfHelpGroup : ChatHub
    {
        public string Title { get; set; }

        public IList<Client> Clienten { get; set; }
    }
}