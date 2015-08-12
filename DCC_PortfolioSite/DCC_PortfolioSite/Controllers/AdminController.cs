using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCC_PortfolioSite.Controllers
{
    public class AdminController : Controller
    {

        AlumniDBModel db = new AlumniDBModel();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // Get: Resume
        public ActionResult Resume()
        {
            UserResume results = db.UserResumes.FirstOrDefault(r => r.ProfileID == 2);
                            

            return View("Resume", results);
        }


    }
}