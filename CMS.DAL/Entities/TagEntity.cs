using System;
using System.Collections.Generic;

namespace CMS.DAL.Entities
{
    public class TagEntity : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public ICollection<ArticleEntity> Articles { get; set; }
        public ICollection<EventEntity> Events { get; set; }
        public ICollection<GalleryEntity> Galleries { get; set; }
    }
}