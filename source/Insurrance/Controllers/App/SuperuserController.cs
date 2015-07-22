using Insurrance.Models.Entities;
using Insurrance.Models.ViewModels;
using Insurrance.Repository;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace Insurrance.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SuperuserController : Controller
    {
        private GenericRepository<Superuser> context = null;
        private SuperuserRepo superUserRepo = null;

        public SuperuserController()
        {
            context = new GenericRepository<Superuser>();
        }

        // Danh sach Superuser
        public ActionResult Index()
        {
            superUserRepo = new SuperuserRepo();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAdd model)
        {
            if (ModelState.IsValid)
            {
                superUserRepo = new SuperuserRepo(context, HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
                superUserRepo.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}