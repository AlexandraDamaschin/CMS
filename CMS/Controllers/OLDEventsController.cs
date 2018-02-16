﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin, Administration")]
    public class oldEventsController : Controller
    {
        private readonly CmsContext db = new CmsContext();

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var events = GetEventList();
            return View(await events.ToListAsync());
        }

        // GET: Events
        public IQueryable<Event> GetEventList()
        {
            IQueryable<Event> events = db.Events
                .Include(db => db.AssociatedEventCategory)
                .Include(db => db.AssociatedLocation)
                .Include(db => db.AssociatedOrganiser);
            //  .Include(db => db.tags);
            return events;

        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }





        public ActionResult New()
        {
            var tags = db.Tags.ToList();
            var viewModel = new EventFormViewModel()
            {
                Event = new Event(),
                AssociatedTags = tags
            };

            return View("CMS.ViewModel.EventFormViewModel", viewModel);
        }

        
        //  Post : /events/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Event event)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel()
                {
                    Event = event,
                    AssociatedTags = db.Locations.ToList()
                };

                return View("EventForm", viewModel);
            }

            if (Event.EventId == 0)
                db.Events.Add(event);
            else
            {
                var eventInDb = db.Events.Single(c => c.EventId == event.EventId);

                Mapper.Map(eventInDb, event);

            }

            db.SaveChanges();

            return RedirectToAction("Index", "Events");
        }





        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.EventCategoryId = new SelectList(db.EventCategories, "EventCategoryId", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "DisplayName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,Name,Details,Priority,StartTime,EndTime,OrganiserId,EventCategoryId,LocationId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventCategoryId = new SelectList(db.EventCategories, "EventCategoryId", "Name", @event.EventCategoryId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", @event.LocationId);
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "DisplayName", @event.OrganiserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            var allEventTagsList = db.Tags.ToList();
            var viewModel = new EventFormViewModel
            {
                Event = @event,
                AssociatedTags = db.Tags.ToList()
            };

            return View("EventForm", viewModel);

            //            ViewBag.EventCategoryId = new SelectList(db.EventCategories, "EventCategoryId", "Name", @event.EventCategoryId);
            //            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", @event.LocationId);
            //            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "DisplayName", @event.OrganiserId);
            //            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Name,Details,Priority,StartTime,EndTime,OrganiserId,EventCategoryId,LocationId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventCategoryId = new SelectList(db.EventCategories, "EventCategoryId", "Name", @event.EventCategoryId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", @event.LocationId);
            ViewBag.OrganiserId = new SelectList(db.Organisers, "OrganiserId", "DisplayName", @event.OrganiserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
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
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}