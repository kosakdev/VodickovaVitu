using System;

namespace CMS.DAL.Entities
{
    public class BandCompositionEntity : EntityBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
    }
}