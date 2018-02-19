using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class EventCategoriesController : Controller
    {
        private readonly CmsContext _cms = new CmsContext();

        public ActionResult New()
        {
            var viewModel = new EventCategoryFormViewModel
            {
                EventCategory = new EventCategory()
            };

            return View("EventCategoryForm", viewModel);
        }


        //  Post : /evntCats/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventCategory evntCat)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventCategoryFormViewModel
                {
                    EventCategory = evntCat
                };

                return View("EventCategoryForm", viewModel);
            }

            if (evntCat.EventCategoryId == 0)
                _cms.EventCategories.Add(evntCat);
            else
            {
                var evntCatInDb = _cms.EventCategories.Single(c => c.EventCategoryId == evntCat.EventCategoryId);

                Mapper.Map(evntCatInDb, evntCat);

            }

            _cms.SaveChanges();

            return RedirectToAction("Index", "EventCategories");
        }

        //  Get: /evntCats
        public ViewResult Index()
        {
            return View();
        }

        //   Get :  /evntCats/details/1
        public ActionResult Details(int id)
        {
            var evntCat = _cms.EventCategories
                .SingleOrDefault(c => c.EventCategoryId == id);

            if (evntCat == null)
                return HttpNotFound();

            return View(evntCat);
        }


        //   Get :  /evntCats/edit/1
        public ActionResult Edit(int id)
        {
            var evntCat = _cms.EventCategories.SingleOrDefault(c => c.EventCategoryId == id);

            if (evntCat == null)
                return HttpNotFound();

            var viewModel = new EventCategoryFormViewModel
            {
                EventCategory = evntCat
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
