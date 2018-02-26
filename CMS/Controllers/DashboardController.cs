using System.Linq;
using System.Web.Mvc;
using CMS.Models.CMSModel;
using CMS.ViewModels;
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

        public ViewResult DashboardPanels()
        {
            var devicesCount = _cms.Devices.Count();
            var eventsCount = _cms.Events.Count();
            var eventCategoriesCount = _cms.EventCategories.Count();
            var locationsCount = _cms.Locations.Count();
            var organisersCount = _cms.Organisers.Count();

            var viewModel = new DashboardPanelsViewModel()
            {
                EventsCount = eventsCount,
                EventCategoriesCount = eventCategoriesCount,
                LocationsCount = locationsCount,
                OrganisersCount = organisersCount,
                DevicesCount = devicesCount
            };
            return View("_DashboardPanels", viewModel);
        }
    }
}
