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



        // GET: Dashboard
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult DashboardPanels()
        {
            //            var devicesCount = _cms.Devices.Count();
            //            if (devicesCount < 20)
            //            {
            //                devicesCount = 42;
            //            }


            //            var devicesCount = _cms.Devices.Count();
            //            var eventCount = _cms.Events.Count();
            //            var eventCategoriesCount = _cms.EventCategories.Count();
            //            var locationsCount = _cms.Locations.Count();
            //            var organisersCount = _cms.Organisers.Count();

            var devicesCount = 999;
            var eventCount = 999;
            var eventCategoriesCount = 999;
            var locationsCount = 999;
            var organisersCount = 999;

            var viewModel = new DashboardPanelsViewModel(
            
                devicesCount, 
                eventCount,
                eventCategoriesCount,
                locationsCount,
                organisersCount
            );

            return View("_DashboardPanels", viewModel);
        }

    }
}
