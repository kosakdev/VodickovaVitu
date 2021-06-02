using System;
using Microsoft.AspNetCore.Http;

namespace CMS.Models.BandComposition
{
    public class BandCompositionUpdateModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
    }
}