using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCC_PortfolioSite.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: _ProfilePartialView
        public ActionResult _ProfilePartialView()
        {
            return View();
        }

        // GET: _ProjectPartialView
        public ActionResult _ProjectPartialView()
        {
            return View();
        }

        // GET: _ResumePartialView
        public ActionResult _ResumePartialView()
        {
            return View();
        }

 




    }
}
