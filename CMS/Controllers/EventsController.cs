using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CMS.Models.CMSModel;
using AutoMapper;
using CMS.ViewModels;

namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin, Administration")]
    public class EventsController : Controller
    {
        private CmsContext _cms = new CmsContext();

        //  Get: /evnts
        public ViewResult Index()
        {
            return View();
        }

        //   Get :  /evnts/details/1
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

        //   Get :  /evnts/edit/1
        public ActionResult Edit(int id)
        {
            var evnt = _cms.Events.SingleOrDefault(c => c.EventId == id);

            if (evnt == null)
                return HttpNotFound();

            var viewModel = new EventFormViewModel
            {
                Event = evnt,
                EventCategories = _cms.EventCategories.ToList(),
                Locations = _cms.Locations.ToList(),
                Organisers = _cms.Organisers.ToList(),
            };
            return View("EventForm", viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new EventFormViewModel
            {
                Event = new Event(),
                EventCategories = _cms.EventCategories.ToList(),
                Locations = _cms.Locations.ToList(),
                Organisers = _cms.Organisers.ToList(),
            };
            return View("EventForm", viewModel);
        }

        //  Post : /evnts/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Event evnt)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel
                {
                    Event = evnt,
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
//                Mapper.Map(evntInDb, evnt);
                evntInDb.EventId = evnt.EventId;
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
