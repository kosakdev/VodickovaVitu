using System.Collections.Generic;

namespace CMS.Web.Models
{
    public class CalendarListsModel
    {
        public IEnumerable<CMS.Models.Calendar.CalendarListModel> ActualData { get; set; }
        public IEnumerable<CMS.Models.Calendar.CalendarListModel> OldData { get; set; }
    }
}