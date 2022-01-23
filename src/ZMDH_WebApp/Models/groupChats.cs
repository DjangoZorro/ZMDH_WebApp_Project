using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZMDH_WebApp.Models
{
    public class groupChats{
    
         
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Memory { get; set; }
        
        public List<Client> Clients {get;set;}

    }
}