using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Praktijk
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Plaats { get; set; }
        public string Adres { get; set; }
    }
}
