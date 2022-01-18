using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Moderator
    {
        [Key]
        public int Id { get; set; }

        public IList<Client> Clienten { get; set; }
        
        public IList<Pedagoog> Pedagogen { get; set; }
    }
}