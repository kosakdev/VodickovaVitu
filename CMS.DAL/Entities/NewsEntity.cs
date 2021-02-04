using System;
using CMS.Common.Enums;

namespace CMS.DAL.Entities
{
    public class NewsEntity : EntityBase<Guid>
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public EntityType EntityType { get; set; }
    }
}