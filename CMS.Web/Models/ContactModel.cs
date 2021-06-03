using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Web.Models
{
    public class ContactModel
    {
        [Required]
        [Display(Name="Jméno *")]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name="Email *")]
        public string Email { get; set; }
        [Required]
        [Display(Name="Datum *")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        [Required]
        [Display(Name="Místo *")]
        public string Place { get; set; }
        [Required]
        [Display(Name="Telefon")]
        public string MobileNumber { get; set; }
        [Display(Name="Další pozvánky")]
        public string Notes { get; set; }
        [Required]
        [Display(Name="Složení kapely *")]
        public Guid BandCompositionId { get; set; }
        [Required]
        [Display(Name="Typ akce *")]
        public Guid EventTypeId { get; set; }
    }
}