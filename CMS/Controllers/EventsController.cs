using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models.CMSModel;


namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin, Administration")]
    public class EventsController : Controller
    {
        private CmsContext _db = new CmsContext();


        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var devices = GetEventList(); ;
            return View(await devices.ToListAsync());
        }
        public IQueryable<Event> GetEventList()
        {
            IQueryable<Event> events = _db.Events.Include(db => db.AssociatedEvent);
            // some really complex logic about creating device lists here. All its concerned with is creating a list of devices
            // and returning it to the caller. Everything else is handled by the caller
            return events;

        }

        //  GET: Events by DeviceId for Raspberry Pi
        //[HttpGet]
        //[Route("device/{deviceId}/device-events")]
        //public List<Event> DeviceEventsList(int deviceId)
        //{
        //    DateTime now = DateTime.UtcNow.Date;
        //    var deviceEvents = db.Events
        //                        .Join(db.Devices,
        //                            evnt => evnt.LocationId,
        //                            dev => dev.LocationId,
        //                            (evnt, dev) => new { Event = evnt, Device = dev })
        //                        .Where(evntAndDev => evntAndDev.Device.DeviceId == deviceId
        //                            && evntAndDev.Event.StartTime >= now)
        //                        .Select(evntAndDev => new { evntAndDev.Event });
        //    return deviceEvents.ToList();
        //}


        // GET: Events
        //public ActionResult Index()
        //{
        //     var events = _db.Events.Include(ec => ec.AssociatedEvent).Include(ec => ec.AssociatedLocation);
        //     return View(events.ToList());
           
        //}

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.EventCatId = new SelectList(_db.EventCategories, "EventCatId", "EventCatId");
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "LocationId");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventCatId,LocationId,Name,StartTime,EndTime,OrganiserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(@event);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventCatId = new SelectList(_db.EventCategories, "EventCatId", "Name", @event.EventCatId);
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name", @event.LocationId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventCatId = new SelectList(_db.EventCategories, "EventCatId", "Name", @event.EventCatId);
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name", @event.LocationId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventCatId,LocationId,Name,StartTime,EndTime,OrganiserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(@event).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventCatId = new SelectList(_db.EventCategories, "EventCatId", "Name", @event.EventCatId);
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name", @event.LocationId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _db.Events.Find(id);
            _db.Events.Remove(@event);
            _db.SaveChanges();
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
