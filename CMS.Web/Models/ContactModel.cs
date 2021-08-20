using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Web.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage="Pole Jméno je povinné")]
        [Display(Name="Jméno *")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage="Pole Email je povinné")]
        [Display(Name="Email *")]
        public string Email { get; set; }
        [Required(ErrorMessage="Pole Datum je povinné")]
        [Display(Name="Datum *")]
        [DataType(DataType.Date, ErrorMessage = "Datum v nesprávném formátu")]
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage="Pole Místo je povinné")]
        [Display(Name="Místo *")]
        public string Place { get; set; }
        [Display(Name = "Telefon")] 
        [DataType(DataType.PhoneNumber, ErrorMessage = "Datum v nesprávném formátu")]
        public string MobileNumber { get; set; }
        [Display(Name="Další pozvánky")]
        public string Notes { get; set; }
        [Required(ErrorMessage="Pole Složení kapely je povinné")]
        [Display(Name="Složení kapely *")]
        public Guid BandCompositionId { get; set; }
        [Required(ErrorMessage="Pole Typ akce je povinné")]
        [Display(Name="Typ akce *")]
        public Guid EventTypeId { get; set; }
    }
}