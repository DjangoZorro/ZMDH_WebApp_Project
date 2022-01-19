using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Client : IdentityUser
    {
        public int ConditionId { get; set; }
        public int GuardianId { get; set; }
        public int ModeratorId { get; set; }
        public int PedagoogId { get; set; }
        public int SelfHelpGroupId { get; set; }

        public Condition Condition { get; set; }

        public Guardian Guardian { get; set; }

        public Moderator Moderator { get; set; }

        public Pedagoog Pedagoog { get; set; }

        public SelfHelpGroup SelfHelpGroup { get; set; }
    }
}