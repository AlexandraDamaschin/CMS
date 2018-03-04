using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class EventsViewModel
    {

        public IEnumerable<Event> Events { get; set; }

        public string SearchTerm { get; set; }
    }
}