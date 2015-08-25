using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System.Configuration;
using System.IO;

namespace DCC_PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        AlumniDBModel db = new AlumniDBModel();

        public ActionResult Index(List<ContactProfile> SearchResults)
        {
            List<ContactProfile> results = null;

            if (SearchResults != null)
            {
                results = SearchResults.ToList();
            }
            return View("Index", results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to the devCodeCamp Alumni Network.";

            return View();
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Contact devCodeCamp at:";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Error";

            return View();
        }



        public ActionResult Search(string tb_SearchBox)
        {
            if (string.IsNullOrEmpty(tb_SearchBox))
            {
                tb_SearchBox = "";
            }
            var results = (from contact in db.ContactProfiles
                            where
                                contact.FirstName.Contains(tb_SearchBox)
                                || contact.LastName.Contains(tb_SearchBox)
                                || contact.AlternateEmail.Contains(tb_SearchBox)
                                || contact.PrimaryEmail.Contains(tb_SearchBox)
                                || contact.About.Contains(tb_SearchBox)
                                || contact.Country.Contains(tb_SearchBox)
                                || contact.USAState.Contains(tb_SearchBox)
                            select contact).ToList();
            
            return View("Index", results);
        }


        public ActionResult GetImg(int ProfileId)
        {
            ContactProfile profile = db.ContactProfiles.Single(p => p.ProfileId == ProfileId);
            if (profile != null & profile.Img != null)
            {
                return new FileContentResult(profile.Img, "image/png");
            }
            return null;
        }
    }
}