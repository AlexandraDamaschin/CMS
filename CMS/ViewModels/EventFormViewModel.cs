using System.Collections.Generic;
using System.Linq;
using CMS.Models.CMSModel;
using System.Web.Mvc;

namespace CMS.ViewModels
{
    public class EventFormViewModel
    {
        public Event Event { get; set; }

        public IEnumerable<SelectListItem> AllTags { get; set; }

        private List<int> _associatedTags;
        public List<int> AssociatedTags
        {
            get { return _associatedTags ?? (_associatedTags = Event.AssociatedTags.Select(t => t.TagId).ToList()); }
            set { _associatedTags = value; }
        }
    }
}