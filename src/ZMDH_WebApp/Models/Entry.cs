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
        [Display(Name = "Volledige naam *")]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Selecteer uw geboortedatum.")]
        [Display(Name = "Geboortedatum *")]
        public string BirthDate { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Vul alstublieft een postcode in.")]
        [Display(Name = "Postcode *")]
        public string ZipCode { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een stad in.")]
        [RegularExpression(@"^[a-zA-Z'@&#.\s]{1,50}$", ErrorMessage = "Stad bestaat niet.")]
        [Display(Name = "Stad *")]
        public string CityName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een huisnummer in.")]
        [Display(Name = "Huisnummer *")]
        public string HouseNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vul alstublieft een telefoonnummer in.")]
        [Display(Name = "Telefoonnummer *")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Vul alstublieft een emailadres in.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "E-Mail is niet geldig.")]
        [Display(Name = "E-Mailadres *")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Selecteer alstublieft een conditie.")]
        [Display(Name = "Conditie *")]
        public int ConditionId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Ouder/Voogd naam")]
        public string GuardianName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "E-Mail is niet geldig.")]
        [Display(Name = "E-Mailadres van ouder/voogd")]
        public string EmailAddressGuardian { get; set; }

        public Condition Condition { get; set; }
    }
}