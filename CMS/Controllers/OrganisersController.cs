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
    [Authorize(Roles = "SuperAdmin")]
    public class OrganisersController : Controller
    {
        private CmsContext db = new CmsContext();

        // GET: Organisers
        public ActionResult Index()
        {
            return View(db.Organisers.ToList());
        }

        // GET: Organisers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organiser organiser = db.Organisers.Find(id);
            if (organiser == null)
            {
                return HttpNotFound();
            }
            return View(organiser);
        }

        // GET: Organisers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganiserId,DisplayName,ContactDetails")] Organiser organiser)
        {
            if (ModelState.IsValid)
            {
                db.Organisers.Add(organiser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organiser);
        }

        // GET: Organisers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organiser organiser = db.Organisers.Find(id);
            if (organiser == null)
            {
                return HttpNotFound();
            }
            return View(organiser);
        }

        // POST: Organisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganiserId,DisplayName,ContactDetails")] Organiser organiser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organiser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organiser);
        }

        // GET: Organisers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organiser organiser = db.Organisers.Find(id);
            if (organiser == null)
            {
                return HttpNotFound();
            }
            return View(organiser);
        }

        // POST: Organisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organiser organiser = db.Organisers.Find(id);
            db.Organisers.Remove(organiser);
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
