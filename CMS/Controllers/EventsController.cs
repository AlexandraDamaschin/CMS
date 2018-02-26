using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Mvc;
using CMS.Models.CMSModel;
using AutoMapper;
using CMS.Dtos;
using CMS.Models;
using CMS.ViewModels;

namespace CMS.Controllers
{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventsController : Controller
    {
        private readonly CmsContext _cms;

        public EventsController()
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

        //  Get events by location id
        public IEnumerable<EventDto> GetLocationEventList(int id)
        {
            var  eventsQuery = _cms.Events
                .Where(m => m.LocationId == id)
                .Include(db => db.AssociatedLocation)
                .Include(db => db.AssociatedEventCategory)
                .Include(db => db.AssociatedOrganiser);
            return eventsQuery
                .ToList()
                .Select(Mapper.Map<Event, EventDto>);
        }

        //  Get:  /events
        public ViewResult Index()
        {
            return View(User.IsInRole(RoleHelper.CanManageEvents) ? "List" : "ReadOnlyList");
        }


        //  Get : /events/new
        [Authorize(Roles = RoleHelper.CanManageEvents)]
        public ViewResult New()
        {
            var eventCategories = _cms.EventCategories.ToList();
            var locations = _cms.Locations.ToList();
            var organisers = _cms.Organisers.ToList();

            var viewModel = new EventFormViewModel
            {
                EventCategories = eventCategories,
                Locations = locations,
                Organisers = organisers
            };
            return View("EventForm", viewModel);
        }


        // Get : /events/edit/1
        [Authorize(Roles = RoleHelper.CanManageEvents)]
        public ActionResult Edit(int id)
        {
            var evnt = _cms.Events
                .SingleOrDefault(c => c.EventId == id);

            if (evnt == null)
                return HttpNotFound();

            var viewModel = new EventFormViewModel(evnt)
            {
                EventCategories = _cms.EventCategories.ToList(),
                Locations = _cms.Locations.ToList(),
                Organisers = _cms.Organisers.ToList(),
            };
            return View("EventForm", viewModel);
        }

        // Get : /events/details/1
        public ActionResult Details(int id)
        {
            var evnt = _cms.Events
                .Include(c => c.AssociatedEventCategory)
                .Include(c => c.AssociatedLocation)
                .Include(c => c.AssociatedOrganiser)
                .SingleOrDefault(c => c.EventId == id);

            if (evnt == null)
                return HttpNotFound();

            return View(evnt);
        }

        //  Post : /events/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleHelper.CanManageEvents)]
        public ActionResult Save(Event evnt)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel(evnt)
                {   
                    EventCategories = _cms.EventCategories.ToList(),
                    Locations = _cms.Locations.ToList(),
                    Organisers = _cms.Organisers.ToList()
                };
                return View("EventForm", viewModel);
            }

            if (evnt.EventId == 0)
                _cms.Events.Add(evnt);
            else
            {
                var evntInDb = _cms.Events.Single(c => c.EventId == evnt.EventId);
                evntInDb.Priority = evnt.Priority;
                evntInDb.Details = evnt.Details;
                evntInDb.StartTime = evnt.StartTime;
                evntInDb.EndTime = evnt.EndTime;
                evntInDb.LocationId = evnt.LocationId;
                evntInDb.OrganiserId = evnt.OrganiserId;
                evntInDb.EventCategoryId = evnt.EventCategoryId;
            }
            _cms.SaveChanges();
            return RedirectToAction("Index", "Events");
        }
    }
}
