using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CMS.Models;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class LocationsController : Controller
    {
        private CmsContext _cms;

        public LocationsController()
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


        //  Get: /locations
        public ViewResult Index()
        {
            return View(User.IsInRole(RoleHelper.CanManageLocations) ? "List" : "ReadOnlyList");
        }


        //  Get: /locations/new
        [Authorize(Roles = RoleHelper.CanManageLocations)]
        public ActionResult New()
        {
            var viewModel = new LocationFormViewModel
            {
                Location = new Location(),
            };

            return View("LocationForm", viewModel);
        }


        //   Get :  /locations/edit/1
        [Authorize(Roles = RoleHelper.CanManageLocations)]
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


        //   Get :  /locations/details/1
        public ActionResult Details(int id)
        {
            var location = _cms.Locations
                .SingleOrDefault(m => m.LocationId == id);

            if (location == null)
                return HttpNotFound();

            return View(location);
        }


        //  Post : /locations/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleHelper.CanManageLocations)]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LocationFormViewModel()
                {
                    Location = new Location()
                };

                return View("LocationForm", viewModel);
            }

            if (location.LocationId == 0)
                _cms.Locations.Add(location);
            else
            {
                var locationInDb = _cms.Locations.Single(m => m.LocationId == location.LocationId);

                locationInDb.Name = location.Name;
                locationInDb.Town = location.Town;
                locationInDb.County = location.County;
                locationInDb.Lat = location.Lat;
                locationInDb.Lng = location.Lng;
            }

            _cms.SaveChanges();
            return RedirectToAction("Index", "Locations");
        }
    }
}
