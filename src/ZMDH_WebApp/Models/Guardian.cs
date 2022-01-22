using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Guardian
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string name { get; set; }
        
        public IList<Client> client { get; set; }
    }
}