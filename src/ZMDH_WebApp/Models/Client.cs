using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Client : IdentityUser
    {
        public int ConditionId { get; set; }
        public int? GuardianId { get; set; }
        public int? SelfHelpGroupId { get; set; }
        public int? TherapyId { get; set; }

        public Condition Condition { get; set; }

        public Guardian Guardian { get; set; }

        public SelfHelpGroup SelfHelpGroup { get; set; }

        public Therapy Therapy { get; set; }
    }
}