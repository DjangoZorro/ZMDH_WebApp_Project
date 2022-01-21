using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Moderator : IdentityUser
    {
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string name { get; set; }
    }
}