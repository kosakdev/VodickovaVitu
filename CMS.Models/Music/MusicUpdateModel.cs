using System;

namespace CMS.Models.Music
{
    public class MusicUpdateModel
    {
        public Guid Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
    }
}