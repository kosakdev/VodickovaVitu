using System;

namespace CMS.DAL.Entities
{
    public class EventTypeEntity : EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}