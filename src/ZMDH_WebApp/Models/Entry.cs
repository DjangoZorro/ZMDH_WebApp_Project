using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZMDH_WebApp.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft uw volledige naam in."), MaxLength(45)]
        [Display(Name = "Volledige naam")]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Selecteer uw geboortedatum.")]
        [Display(Name = "Geboortedatum")]
        public string BirthDate { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Vul alstublieft een postcode in.")]
        [RegularExpression(@"/^[1-9][0-9]{3} ?(?!sa|sd|ss)[a-z]{2}$/i", ErrorMessage = "Ongeldige postcode.")]
        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een stad in.")]
        [RegularExpression(@"^[a-zA-Z'@&#.\s]{1,50}$", ErrorMessage = "Stad bestaat niet.")]
        [Display(Name = "Stad")]
        public string CityName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een huisnummer in.")]
        [Display(Name = "Huisnummer")]
        public string HouseNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een telefoonnummer in.")]
        [RegularExpression(@"^\+316\d{8}$", ErrorMessage = "Telefoonnummer bestaat niet.")]
        [Display(Name = "Telefoonnummer")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Vul alstublieft een emailadres in.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "E-Mail is niet geldig.")]
        [Display(Name = "E-Mailadres")]
        public string EmailAddress { get; set; }

        public int ConditionId { get; set; }

        [Required(ErrorMessage = "Selecteer uw conditie.")]
        [Display(Name = "Conditie")]
        public Condition Condition { get; set; }
    }
}