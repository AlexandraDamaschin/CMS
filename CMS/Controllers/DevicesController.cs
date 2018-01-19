using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CMS.Models.CMSModel;

namespace CMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DevicesController : Controller
    {
        private CmsContext _db = new CmsContext();

//        public ActionResult New()
//        {
//            var locations = db.Locations.ToList();
//            var viewModel = new NewDeviceViewModel
//            {
//                Locations = locations
//            };
//            return View(viewModel);
//        }


        // GET: Devices
        public async Task<ActionResult> Index()
        {
            var devices = _db.Devices.Include(d => d.AssociatedLocation);
            return View(await devices.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await _db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: Devices/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DeviceId,LocationId,Build")] Device device)
        {
            if (ModelState.IsValid)
            {
                _db.Devices.Add(device);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name", device.LocationId);
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await _db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name", device.LocationId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DeviceId,LocationId,Build")] Device device)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(device).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name", device.LocationId);
            return View(device);
        }

        // GET: Devices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await _db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Device device = await _db.Devices.FindAsync(id);
            _db.Devices.Remove(device);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
