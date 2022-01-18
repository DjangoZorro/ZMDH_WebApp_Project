using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ZMDH_WebApp.Models
{
    public class Guardian : IdentityUser
    {
        public IList<Client> client { get; set; }
    }
}