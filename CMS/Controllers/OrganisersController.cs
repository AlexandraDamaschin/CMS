using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class OrganisersController : Controller
    {
        private CmsContext _cms = new CmsContext();

        //  Get: /organisers
        public ViewResult Index()
        {
            return View();
        }

        //   Get :  /organisers/details/1
        public ActionResult Details(int id)
        {
            var organiser = _cms.Organisers.SingleOrDefault(m => m.OrganiserId == id);
            if (organiser == null)
                return HttpNotFound();

            return View(organiser);
        }

        //   Get :  /organisers/edit/1
        public ActionResult Edit(int id)
        {
            var organiser = _cms.Organisers.SingleOrDefault(m => m.OrganiserId == id);
            if (organiser == null)
                return HttpNotFound();

            var viewModel = new OrganiserFormViewModel
            {
                Organiser = organiser
            };
            return View("OrganiserForm", viewModel);
        }

        // Get : /organisers/new
        public ActionResult New()
        {
            var viewModel = new OrganiserFormViewModel
            {
                Organiser = new Organiser(),
            };
            return View("OrganiserForm", viewModel);
        }

        //  Post : /organisers/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Organiser organiser)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new OrganiserFormViewModel()
                {
                    Organiser = new Organiser()
                };
                return View("OrganiserForm", viewModel);
            }
            if (organiser.OrganiserId == 0)
                _cms.Organisers.Add(organiser);
            else
            {
                var organiserInDb = _cms.Organisers.Single(m => m.OrganiserId == organiser.OrganiserId);
//                Mapper.Map(organiserInDb, organiser);
                organiserInDb.DisplayName = organiser.DisplayName;
                organiserInDb.ContactDetails = organiser.ContactDetails;
                organiserInDb.OrganiserId = organiser.OrganiserId;
            }
            _cms.SaveChanges();
            return RedirectToAction("Index", "Organisers");
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




