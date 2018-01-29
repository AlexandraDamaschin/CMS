using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CMS.Models.CMSModel;

namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin,Administration")]
    public class EventCategoriesController : Controller
    {
        private CmsContext _db = new CmsContext();

        // GET: EventCategories
        public ActionResult Index()
        {
            return View(_db.EventCategories.ToList());
        }

        // GET: EventCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCategory eventCategory = _db.EventCategories.Find(id);
            if (eventCategory == null)
            {
                return HttpNotFound();
            }
            return View(eventCategory);
        }

        // GET: EventCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventCategoryId,Name,Outdoor,Family")] EventCategory eventCategory)
        {
            if (ModelState.IsValid)
            {
                _db.EventCategories.Add(eventCategory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventCategory);
        }

        // GET: EventCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCategory eventCategory = _db.EventCategories.Find(id);
            if (eventCategory == null)
            {
                return HttpNotFound();
            }
            return View(eventCategory);
        }

        // POST: EventCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventCategoryId,Name,Outdoor,Family")] EventCategory eventCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(eventCategory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventCategory);
        }

        // GET: EventCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCategory eventCategory = _db.EventCategories.Find(id);
            if (eventCategory == null)
            {
                return HttpNotFound();
            }
            return View(eventCategory);
        }

        // POST: EventCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventCategory eventCategory = _db.EventCategories.Find(id);
            _db.EventCategories.Remove(eventCategory);
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
