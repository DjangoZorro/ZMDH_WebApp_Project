using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Diploma
    {
        [DataType(DataType.Text)]
        [Display(Name = "Diploma")]
        public string DiplomaName { get; set; }

        public virtual ICollection<Pedagoog> Pedagogen { get; set; }
    }
}