using System;
using System.ComponentModel.DataAnnotations;
using CMS.Models.EventType;

namespace CMS.Models.Calendar
{
    public class CalendarListModel
    {
        public Guid Id { get; set; }
        [Display(Name="Popis")]
        public string Description { get; set; }
        [Display(Name="Datum")]
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public Guid EventTypeId { get; set; }
        public EventTypeListModel EventType { get; set; }
    }
}