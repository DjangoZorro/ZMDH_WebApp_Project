using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Client : IdentityUser
    {
        public Condition Condition { get; set; }

        public Guardian Guardian { get; set; }

        public Moderator Moderator { get; set; }

        public Pedagoog Pedagoog { get; set; }
    }
}