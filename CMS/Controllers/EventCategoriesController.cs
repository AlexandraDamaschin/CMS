using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class EventCategoriesController : Controller
    {
        private CmsContext _cms = new CmsContext();

        public ActionResult New()
        {
            var viewModel = new EventCategoryFormViewModel
            {
                EventCategory = new EventCategory()
            };

            return View("EventCategoryForm", viewModel);
        }


        //  Post : /eventCategories/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventCategory eventCategory)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventCategoryFormViewModel
                {
                    EventCategory = eventCategory
                };

                return View("EventCategoryForm", viewModel);
            }

            if (eventCategory.EventCategoryId == 0)
                _cms.EventCategories.Add(eventCategory);
            else
            {
                var eventCategoryInDb = _cms.EventCategories.Single(c => c.EventCategoryId == eventCategory.EventCategoryId);

                Mapper.Map(eventCategoryInDb, eventCategory);

            }

            _cms.SaveChanges();

            return RedirectToAction("Index", "EventCategories");
        }

        //  Get: /eventCategories
        public ViewResult Index()
        {
            return View();
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


        //   Get :  /eventCategories/edit/1
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
