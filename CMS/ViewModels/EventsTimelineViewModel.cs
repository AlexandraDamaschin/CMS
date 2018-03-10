using CMS.Models.CMSModel;
using System.Linq;

namespace CMS.ViewModels
{
    public class EventsTimelineViewModel
    {

        public int EventsCount { get; set; }
        public IQueryable<Event> TopEvents { get; set; }
    }
}