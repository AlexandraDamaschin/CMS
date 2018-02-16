using System.Collections.Generic;
using System.Linq;
using CMS.Models.CMSModel;
using System.Web.Mvc;

namespace CMS.ViewModels
{
    public class EventFormViewModel
    {
        public Event Event { get; set; }

        public IEnumerable<SelectListItem> AllEventTags { get; set; }

        private List<int> _associatedTags;
        public List<int> AssociatedTags
        {
            get
            {
                if (_associatedTags == null)
                {
                    _associatedTags = Event.AssociatedTags.Select(t => t.TagId).ToList();
                }

                return _associatedTags;
            }
            set { _associatedTags = value; }
        }
    }
}