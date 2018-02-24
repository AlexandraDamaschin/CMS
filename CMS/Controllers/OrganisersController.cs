using System.Linq;
using System.Web.Mvc;
using CMS.Models;
using CMS.Models.CMSModel;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class OrganisersController : Controller
    {
        private CmsContext _cms;

        public OrganisersController()
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


        //  Get: /organisers
        public ViewResult Index()
        {
            return View(User.IsInRole(RoleHelper.CanManageOrganisers) ? "List" : "ReadOnlyList");
        }



        // Get : /organisers/new
        [Authorize(Roles = RoleHelper.CanManageOrganisers)]
        public ActionResult New()
        {
            var viewModel = new OrganiserFormViewModel
            {
                Organiser = new Organiser(),
            };
            return View("OrganiserForm", viewModel);
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


        //   Get :  /organisers/details/1
        public ActionResult Details(int id)
        {
            var organiser = _cms.Organisers.SingleOrDefault(m => m.OrganiserId == id);
            if (organiser == null)
                return HttpNotFound();

            return View(organiser);
        }

 
        //  Post : /organisers/save/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleHelper.CanManageOrganisers)]
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

                organiserInDb.DisplayName = organiser.DisplayName;
                organiserInDb.ContactDetails = organiser.ContactDetails;
                organiserInDb.OrganiserId = organiser.OrganiserId;
            }
            _cms.SaveChanges();
            return RedirectToAction("Index", "Organisers");
        }
    }
}




