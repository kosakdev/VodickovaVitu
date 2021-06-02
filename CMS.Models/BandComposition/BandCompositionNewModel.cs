using System;
using Microsoft.AspNetCore.Http;

namespace CMS.Models.BandComposition
{
    public class BandCompositionNewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
    }
}