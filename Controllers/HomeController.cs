using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GB.Models;
using MvcSiteMapProvider;
namespace GB.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var profile = UserProfile.GetProfile(User.Identity.Name);

                ViewBag.Message = "Hello " + profile.FirstName + " " + profile.LastName + "!";
            }
            else
            {
                ViewBag.Message = "Please log on!";
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
