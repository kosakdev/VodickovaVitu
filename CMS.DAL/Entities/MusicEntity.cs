using System;

namespace CMS.DAL.Entities
{
    public class MusicEntity : EntityBase<Guid>
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
    }
}