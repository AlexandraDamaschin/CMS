using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class EventCategoryFormViewModel
    {
        public EventCategory EventCategory { get; set; }

        public string Title => EventCategory.EventCategoryId != 0 ? "Edit Event Category" : "New Event Category";

    }
}