using System;
using System.Collections.Generic;
using CMS.Common.Enums;

namespace CMS.DAL.Entities
{
    public class GalleryEntity : EntityBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreviewImg { get; set; }
        public string Url { get; set; }
        public DateTime DateTime { get; set; }
        public Guid ParentId { get; set; }
        
        public SortByType SortBy { get; set; }
        
        public ICollection<TagEntity> Tags { get; set; }
    }
}