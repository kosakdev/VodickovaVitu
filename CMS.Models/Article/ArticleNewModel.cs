using System;
using System.ComponentModel.DataAnnotations;
using CMS.Common.Enums;

namespace CMS.Models.Article
{
    public class ArticleNewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Url { get; set; }
        public DateTime PublicationDateTime { get; set; }
        public string Text { get; set; }
        public bool Draft { get; set; }
        public PageType PageType { get; set; }
    }
}