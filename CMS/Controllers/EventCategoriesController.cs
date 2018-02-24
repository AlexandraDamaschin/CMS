using System.Linq;
using System.Web.Mvc;
using CMS.Models;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class EventCategoriesController : Controller
    {
        private CmsContext _cms;

        public EventCategoriesController()
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


        //  Get: /eventCategories
        public ViewResult Index()
        {
            return View(User.IsInRole(RoleName.CanManageEventCategories) ? "List" : "ReadOnlyList");
        }


        //  Get : /eventCategories/new
        [Authorize(Roles = RoleName.CanManageEventCategories)]
        public ViewResult New()
        {
            var viewModel = new EventCategoryFormViewModel
            {
                EventCategory = new EventCategory()
            };
            return View("EventCategoryForm", viewModel);
        }


        //   Get :  /eventCategories/edit/1
        [Authorize(Roles = RoleName.CanManageEventCategories)]
        public ActionResult Edit(int id)
        {
            var eventCategory = _cms.EventCategories.SingleOrDefault(c => c.EventCategoryId == id);

            if (eventCategory == null)
                return HttpNotFound();

            var viewModel = new EventCategoryFormViewModel
            {
                EventCategory = eventCategory
            };

            return View("EventCategoryForm", viewModel);
        }


        //   Get :  /eventCategories/details/1
        public ActionResult Details(int id)
        {
            var eventCategory = _cms.EventCategories
                .SingleOrDefault(c => c.EventCategoryId == id);

            if (eventCategory == null)
                return HttpNotFound();

            return View(eventCategory);
        }


        //  Post : /eventCategories/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageEventCategories)]
        public ActionResult Save(EventCategory eventCategory)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventCategoryFormViewModel()
                {
                    EventCategory = new EventCategory()
                };

                return View("EventCategoryForm", viewModel);
            }

            if (eventCategory.EventCategoryId == 0)
                _cms.EventCategories.Add(eventCategory);
            else
            {
                var eventCategoryInDb = _cms.EventCategories.Single(c => c.EventCategoryId == eventCategory.EventCategoryId);
                eventCategoryInDb.Name = eventCategory.Name;
//                Mapper.Map(eventCategoryInDb, eventCategory);

            }

            _cms.SaveChanges();

            return RedirectToAction("Index", "EventCategories");
        }
    }
}
