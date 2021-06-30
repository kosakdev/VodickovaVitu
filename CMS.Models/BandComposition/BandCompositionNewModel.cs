using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CMS.Models.BandComposition
{
    public class BandCompositionNewModel
    {
        [Display(Name = "Název")]
        public string Title { get; set; }
        [Display(Name = "Popis")]
        public string Description { get; set; }
        [Display(Name = "Soubor")]
        public IFormFile FormFile { get; set; }
        [Display(Name = "Název souboru")]
        public string FileName { get; set; }
    }
}