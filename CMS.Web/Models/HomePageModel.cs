using System.Collections.Generic;

namespace CMS.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<CMS.Models.Calendar.CalendarListModel> CalendarList { get; set; }
    }
}