using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.EventType
{
    public class EventTypeUpdateModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Název události")]
        public string Name { get; set; }
    }
}