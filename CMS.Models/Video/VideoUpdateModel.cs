using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.Video
{
    public class VideoUpdateModel
    {
        public Guid Id { get; set; }
        [Display(Name = "YouTube url (za ?v=)")]
        public string VideoLink { get; set; }
    }
}