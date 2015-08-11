using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace DCC_PortfolioSite.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            UserProfileViewModels model = new UserProfileViewModels();
            model.Address = "123 W. 4th Street";
            model.AlternateEmail = "bob@google.com";
            model.AlternatePhone = "414-232-5139";
            model.AvailableForWorkMessage = "I am looking for work doing Machine Learning.";
            model.City = "Milwaukee";
            model.Country = "USA";
            model.CurrentlyWorkingOnMessage = "I am currently working on a project for McDonalds, order number 16, Fries and a BigMac.";
            model.GitHubProfile = "http://www.GitHub.com/mkohlmann-he";
            model.HireByMessage = "I have not been hired yet";
            model.LinkInProfile = "http://www.linkedin.com/5/14/blahblah";
            model.PersonalWebsite = "http://www.PersonWebsite.Com";
            model.PrimaryEmail = "mkohlmann_he@dev.bse.edu";
            model.PrimaryPhone = "414-pri-mary";
            model.ProfilePhoto = null;
            model.ProjectSpotLightObjectList = null;
            model.ResumeViewModelObject = null;
            model.ShowAddress = true;
            model.ShowAlternateEmail = true;
            model.ShowAlternatePhone = true;
            model.ShowAvailableForWorkMessage = true;
            model.ShowCurrentlyWorkingOnMessage = true;
            model.ShowGitHubProfile = true;
            model.ShowHireByMessage = true;
            model.ShowLinkInProfile = true;
            model.ShowPersonalWebsite = true;
            model.ShowPrimaryEmail = true;
            model.ShowPrimaryPhone = true;
            model.ShowProfilePhoto = true;
            model.State = "WI";
            model.UserFirstName = "Bob";
            model.UserLastName = "Smith";
            model.Zip = "53211";
            return View(model);
        }



 




    }
}
