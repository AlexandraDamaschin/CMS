using System.Collections.Generic;
using CMS.Models.CMSModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CMS.ViewModels;

namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin, Administration")]
    public class EventsController : Controller
    {
        private readonly CmsContext _cms = new CmsContext();

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var events = GetEventList();
            return View(await events.ToListAsync());
        }

        // GET: Events
        public IQueryable<Event> GetEventList()
        {
            IQueryable<Event> events = _cms.Events
                .Include(db => db.AssociatedEventCategory)
                .Include(db => db.AssociatedLocation)
                .Include(db => db.AssociatedOrganiser)
                .Include(db => db.AssociatedTags);
            return events;
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _cms.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }




        public ActionResult New()
        {
            List<int> tags = _cms.Tags.Cast<int>().ToList();
            var viewModel = new EventFormViewModel
            {
                Event = new Event(),
                AssociatedTags = tags
            };

            return View("EventForm", viewModel);
        }





    }

}