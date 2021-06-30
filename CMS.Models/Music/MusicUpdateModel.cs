using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.Music
{
    public class MusicUpdateModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Youtube ID - https://www.youtube.com/watch?v=oT8UaGHWcMg")]
        public string VideoId { get; set; }
        [Display(Name = "Název")]
        public string Title { get; set; }
    }
}