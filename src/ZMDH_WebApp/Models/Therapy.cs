using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Therapy
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PedagoogId { get; set; }

        public Client Clienten { get; set; }
        public IList<Pedagoog> Pedagogen { get; set; }
    }
}