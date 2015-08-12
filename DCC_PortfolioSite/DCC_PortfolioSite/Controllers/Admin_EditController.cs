using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCC_PortfolioSite.Controllers
{
    public class Admin_EditController : Controller
    {

        AlumniDBModel db = new AlumniDBModel();

        // GET: Admin_Edit
        public ActionResult Index()
        {
            return View();
        }

    }
}