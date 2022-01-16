using System.Collections.Generic;

namespace ZMDH_WebApp.Models
{
    public class Condition
    {
        public virtual ICollection<Client> Clienten { get; set; }
    }
}