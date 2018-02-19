using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class LocationsController : Controller
    {
        private readonly CmsContext _cms = new CmsContext();

        public ActionResult New()
        {
            var viewModel = new LocationFormViewModel
            {
                Location = new Location(),
            };

            return View("LocationForm", viewModel);
        }


        //  Post : /locations/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LocationFormViewModel()
                {
                    Location = location
                };

                return View("LocationForm", viewModel);
            }

            if (location.LocationId == 0)
                _cms.Locations.Add(location);
            else
            {
                var locationInDb = _cms.Locations.Single(m => m.LocationId == location.LocationId);

                Mapper.Map(locationInDb, location);

            }

            _cms.SaveChanges();

            return RedirectToAction("Index", "Locations");
        }

        //  Get: /locations
        public ViewResult Index()
        {
            return View();
        }

        //   Get :  /locations/details/1
        public ActionResult Details(int id)
        {
            var location = _cms.Locations
                .SingleOrDefault(m => m.LocationId == id);

            if (location == null)
                return HttpNotFound();

            return View(location);
        }


        //   Get :  /locations/edit/1
        public ActionResult Edit(int id)
        {
            var location = _cms.Locations.SingleOrDefault(m => m.LocationId == id);

            if (location == null)
                return HttpNotFound();

            var viewModel = new LocationFormViewModel
            {
                Location = location
            };

            return View("LocationForm", viewModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cms.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}



