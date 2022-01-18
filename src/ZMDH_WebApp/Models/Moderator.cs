using System.Collections.Generic;
using ZMDH_WebApp.Hubs;

namespace ZMDH_WebApp.Models
{
    public class Moderator
    {
        public IList<Client> Clienten { get; set; }
        
        public IList<Pedagoog> Pedagogen { get; set; }
    }
}