using System;

namespace CMS.Models.BandComposition
{
    public class BandCompositionDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
    }
}