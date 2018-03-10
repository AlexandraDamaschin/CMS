using CMS.Models.CMSModel;
using CMS.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace CMS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly CmsContext _cms;

        public DashboardController()
        {
            _cms = new CmsContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cms.Dispose();
            }
            base.Dispose(disposing);
        }

        public PartialViewResult DashboardPanels()
        {
            var viewModel = new DashboardPanelsViewModel()
            {
                EventsCount = _cms.Events.Count(),
                EventCategoriesCount = _cms.EventCategories.Count(),
                LocationsCount = _cms.Locations.Count(),
                OrganisersCount = _cms.Organisers.Count(),
                DevicesCount = _cms.Devices.Count()
            };
            return PartialView("_DashboardPanels", viewModel);
        }

        public PartialViewResult EventsTimeline()
        {
            var viewModel = new EventsTimelineViewModel()
            {
                EventsCount = _cms.Events.Count(),
                TopEvents = _cms.Events
                    .OrderByDescending(m => m.StartTime)
                    .Include(m => m.AssociatedLocation)
                    .Include(m => m.AssociatedEventCategory)
                    .Include(m => m.AssociatedOrganiser)
                    .Take(5)
            };
            return PartialView("_EventsTimeline", viewModel);
        }
    }
}
