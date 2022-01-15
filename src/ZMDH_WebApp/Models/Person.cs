using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Person
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een voornaam in."), MaxLength(45)]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een achternaam in."), MaxLength(45)]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Vul alstublieft een emailadres in")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "E-Mail is niet geldig.")]
        [Display(Name = "E-Mailadres")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een postcode in")]
        [RegularExpression(@"/^[1-9][0-9]{3} ?(?!sa|sd|ss)[a-z]{2}$/i", ErrorMessage = "Ongeldige postcode.")]
        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }

        public string CityName { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}