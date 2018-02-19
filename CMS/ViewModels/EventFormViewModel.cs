using System.Collections.Generic;
using System.Linq;
using CMS.Models.CMSModel;
using System.Web.Mvc;

namespace CMS.ViewModels
{
    public class EventFormViewModel
    {
        public Event Event { get; set; }

        public IEnumerable<Organiser> Organisers { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<EventCategory> EventCategories { get; set; }


    }
}