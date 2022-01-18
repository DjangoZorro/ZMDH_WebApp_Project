using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class SelfHelpGroup
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<Client> Clienten { get; set; }
    }
}