using System;
using CMS.Common.Enums;

namespace CMS.DAL.Entities
{
    public class MenuItemEntity : EntityBase<Guid>
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public EntityType EntityType { get; set; }
    }
}