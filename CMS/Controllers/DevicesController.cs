using System.Data.Entity;
using System.Web.Mvc;
using CMS.Models.CMSModel;
using CMS.ViewModels;
using System.Linq;
using AutoMapper;

namespace CMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DevicesController : Controller
    {
        private CmsContext _cms = new CmsContext();


        //  
        public ActionResult New()
        {
            var locations = _cms.Locations.ToList();
            var viewModel = new DeviceFormViewModel
            {
                Device = new Device(),
                Locations = locations
            };

            return View("DeviceForm", viewModel);
        }


        //  Post : /devices/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Device device)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DeviceFormViewModel
                {
                    Device = device,
                    Locations = _cms.Locations.ToList()
                };

                return View("DeviceForm", viewModel);
            }

            if (device.DeviceId == 0)
                _cms.Devices.Add(device);
            else
            {
                var deviceInDb = _cms.Devices.Single(c => c.DeviceId == device.DeviceId);

                Mapper.Map(deviceInDb, device);

            }

            _cms.SaveChanges();

            return RedirectToAction("Index", "Devices");
        }

        //  Get: /devices
        public ViewResult Index()
        {
            return View();
        }

        //   Get :  /devices/details/1
        public ActionResult Details(int id)
        {
            var device = _cms.Devices.Include(c => c.AssociatedLocation).SingleOrDefault(c => c.DeviceId == id);

            if (device == null)
                return HttpNotFound();

            return View(device);
        }


        //   Get :  /devices/edit/1
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
