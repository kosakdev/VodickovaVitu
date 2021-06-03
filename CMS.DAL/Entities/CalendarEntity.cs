using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DAL.Entities
{
    public class CalendarEntity : EntityBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        
        [ForeignKey(nameof(BandComposition))]
        public Guid BandCompositionId { get; set; }
        public BandCompositionEntity BandComposition { get; set; }
        
        [ForeignKey(nameof(EventType))]
        public Guid EventTypeId { get; set; }
        public EventTypeEntity EventType { get; set; }
    }
}