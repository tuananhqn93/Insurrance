using Insurrance.Models.Entities;
using Insurrance.Models.ViewModels;
using Insurrance.Repository;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
namespace Insurrance.Controllers
{
    public class CallcenterController : Controller
    {
        private GenericRepository<Callcenter> context = null;
        private CallcenterRepo callCenterRepo = null;

        public CallcenterController()
        {
            context = new GenericRepository<Callcenter>();
        }

        // Danh sach Callcenter
        public ActionResult Index()
        {
            callCenterRepo = new CallcenterRepo();
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
                callCenterRepo = new CallcenterRepo(context, HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(), HttpContext.GetOwinContext().Get<ApplicationSignInManager>());
                callCenterRepo.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
