using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class SelfHelpGroup
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        public IList<Client> Clienten { get; set; }
    }
}