using System;
using System.ComponentModel.DataAnnotations;
using CMS.Common.Enums;

namespace CMS.Models.Article
{
    public class ArticleNewModel
    {
        [Display(Name = "Název")]
        public string Title { get; set; }
        [Display(Name = "Popisek")]
        public string Description { get; set; }
        [Display(Name = "URL")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Url { get; set; }
        [Display(Name = "Datum publikování")]
        public DateTime PublicationDateTime { get; set; }
        [Display(Name = "Text")]
        public string Text { get; set; }
        [Display(Name = "Koncept")]
        public bool Draft { get; set; }
        [Display(Name = "Typ stránky")]
        public PageType PageType { get; set; }
    }
}