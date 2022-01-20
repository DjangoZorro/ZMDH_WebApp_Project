using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Condition
    {
        [Key]
        public int Id { get; set; }
        
        public string Naam { get; set; }

        public IList<Client> Clienten { get; set; }

        public IList<Entry> Entries { get; set; }
    }
}