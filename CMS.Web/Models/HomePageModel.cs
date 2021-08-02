using System.Collections.Generic;
using CMS.Models.Article;
using CMS.Models.Video;

namespace CMS.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<CMS.Models.Calendar.CalendarListModel> CalendarList { get; set; }
        public ArticleDetailModel Article { get; set; }
        
        public VideoListModel Video { get; set; }
    }
}