using System.Collections.Generic;
using ZMDH_WebApp.Hubs;

namespace ZMDH_WebApp.Models
{
    public class SelfHelpGroup : ChatHub
    {
        public string Title { get; set; }

        public IList<Client> Clienten { get; set; }
    }
}