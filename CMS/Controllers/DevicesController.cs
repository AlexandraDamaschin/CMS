using System.Data.Entity;
using System.Web.Mvc;
using CMS.Models.CMSModel;
using CMS.ViewModels;
using System.Linq;
using CMS.Models;

namespace CMS.Controllers
{
    public class DevicesController : Controller
    {
        private readonly CmsContext _cms;

        public DevicesController()
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


        //  Get: /devices
        public ViewResult Index()
        {
            return View(User.IsInRole(RoleHelper.CanManageDevices) ? "List" : "ReadOnlyList");
        }

        //  Get : /devices/new
        [Authorize(Roles = RoleHelper.CanManageDevices)]
        public ViewResult New()
        {
            var viewModel = new DeviceFormViewModel
            {
                Device = new Device(),
                Locations = _cms.Locations.ToList()
            };

            return View("DeviceForm", viewModel);
        }


        //   Get :  /devices/edit/1
        [Authorize(Roles = RoleHelper.CanManageDevices)]
        public ActionResult Edit(int id)
        {
            var device = _cms.Devices.SingleOrDefault(c => c.DeviceId == id);

            if (device == null)
                return HttpNotFound();

            var viewModel = new DeviceFormViewModel
            {
                Device = device,
                Locations = _cms.Locations.ToList()
            };

            return View("DeviceForm", viewModel);
        }


        //   Get :  /devices/details/1
        public ActionResult Details(int id)
        {
            var device = _cms.Devices
                .Include(c => c.AssociatedLocation)
                .SingleOrDefault(c => c.DeviceId == id);

            if (device == null)
                return HttpNotFound();

            return View(device);
        }


        //  Post : /devices/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleHelper.CanManageDevices)]
        public ActionResult Save(Device device)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DeviceFormViewModel
                {
                    Device = new Device(),
                    Locations = _cms.Locations.ToList()
                };

                return View("DeviceForm", viewModel);
            }

            if (device.DeviceId == 0)
                _cms.Devices.Add(device);
            else
            {
                var deviceInDb = _cms.Devices.Single(c => c.DeviceId == device.DeviceId);
                deviceInDb.Name = device.Name;
                deviceInDb.Build = device.Build;
                deviceInDb.LocationId = device.LocationId;
                deviceInDb.HasError = false;
            }

            _cms.SaveChanges();
            return RedirectToAction("Index", "Devices");
        }
    }
}
