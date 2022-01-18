using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SignalRChat.Hubs;

namespace ZMDH_WebApp.Models
{
    public class Pedagoog : IdentityUser
    {
        [DataType(DataType.Text)]
        [Display(Name = "Specialisatie")]
        public string Specialization { get; set; }

        public virtual IList<Diploma> Diplomas { get; set; }

        public IList<ChatHub> ChatHub { get; set; }

        public IList<Client> Clienten { get; set; }

        public Moderator Moderator { get; set; }
    }
}