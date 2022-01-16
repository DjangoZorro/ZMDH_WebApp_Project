using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SignalRChat.Hubs;

namespace ZMDH_WebApp.Models
{
    public class Pedagoog : IdentityUser
    {
        [DataType(DataType.Text)]
        [Display(Name = "Soort hulp afdeling")]
        public string SpecializedDepartment { get; set; }

        public virtual ICollection<Diploma> Diplomas { get; set; }

        public ChatHub chatHub { get; set; }
    }
}