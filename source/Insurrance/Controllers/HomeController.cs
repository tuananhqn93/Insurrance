using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Insurrance.Models;

namespace Insurrance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Helpers.Authorize.CreateRole("Admin");
            Helpers.Authorize.CreateRole("Superuser");
            Helpers.Authorize.CreateRole("Callcenter");

            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (UserManager.FindByName("admin") == null)
            {
                var user = new ApplicationUser { UserName = "admin", Email = "admin@ins.com" };
                var result = UserManager.Create(user, "Password123!");
                if (result.Succeeded)
                {
                    UserManager.AddToRole(UserManager.FindByName(user.UserName).Id, "Admin");
                }
            }
            return View();
        }
    }
}