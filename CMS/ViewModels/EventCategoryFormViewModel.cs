using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class EventCategoryFormViewModel
    {
        public EventCategory EventCategory { get; set; }

        public string Title => EventCategory.EventCategoryId != 0 ? "Edit Event Category" : "New Event Category";

        public EventCategoryFormViewModel()
        {
            EventCategory.EventCategoryId = 0;
        }

        public EventCategoryFormViewModel(EventCategory eventCategory)
        {
            EventCategory = new EventCategory
            {
                EventCategoryId = eventCategory.EventCategoryId,
                Name = eventCategory.Name
            };
        }
    }
}