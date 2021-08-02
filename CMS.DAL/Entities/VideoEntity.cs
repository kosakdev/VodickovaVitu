using System;

namespace CMS.DAL.Entities
{
    public class VideoEntity : EntityBase<Guid>
    {
        public string VideoLink { get; set; }
    }
}