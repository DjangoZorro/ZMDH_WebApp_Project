using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Pedagoog : IdentityUser
    {
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Specialisatie")]
        public string Specialization { get; set; }

        public int TherapyId { get; set; }

        public Therapy Therapy { get; set; }
    }
}