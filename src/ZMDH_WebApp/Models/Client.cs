using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ZMDH_WebApp.Hubs;

namespace ZMDH_WebApp.Models
{
    public class Client : IdentityUser
    {
        public Condition Condition { get; set; }

        public Guardian Guardian { get; set; }

        public IList<ChatHub> ChatHub { get; set; }

        public Moderator Moderator { get; set; }

        public Pedagoog Pedagoog { get; set; }
    }
}