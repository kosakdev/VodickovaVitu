using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.Calendar
{
    public class CalendarNewModel
    {
        [Display(Name="Popis")]
        public string Description { get; set; }
        [Display(Name="Datum")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Místo")]
        public string Place { get; set; }
        [Display(Name = "Typ události")]
        public Guid EventTypeId { get; set; }
    }
}