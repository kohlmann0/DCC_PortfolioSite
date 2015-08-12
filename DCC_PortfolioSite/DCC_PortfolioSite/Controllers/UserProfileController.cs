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
        
        AlumniDBModel db = new AlumniDBModel();
        
        // GET: UserProfile
        public ActionResult Index(int? id)
        {
            //  --- Insert Database Pull for matching user ID here ---
            UserProfileViewModels model = new UserProfileViewModels();
            ContactProfile dbContactProfileModel = db.ContactProfiles.FirstOrDefault(i => i.ProfileId == id);

            // Copy over Data
            model.About = dbContactProfileModel.About;
            model.Address = dbContactProfileModel.StreetAddress;
            model.AlternateEmail = dbContactProfileModel.AlternateEmail;
            model.AlternatePhone = dbContactProfileModel.AlternatePhone;
            model.AvailableForWorkMessage = "I am looking for work doing Machine Learning."; // dbContactProfileModel.AvailableForWorkMessage;
            model.City = dbContactProfileModel.City;
            model.Country = dbContactProfileModel.Country;
            model.CurrentlyWorkingOnMessage = dbContactProfileModel.CurrentWork;
            model.GitHubProfile = dbContactProfileModel.GitHub;
            model.HireByMessage = dbContactProfileModel.HiredBy;
            model.LinkInProfile = dbContactProfileModel.LinkedIn;
            model.PersonalWebsite = dbContactProfileModel.PersonalWebsite;
            model.PrimaryEmail = dbContactProfileModel.PrimaryEmail;
            model.PrimaryPhone = dbContactProfileModel.PrimaryPhone;
            model.ProfilePhoto = dbContactProfileModel.Photo;
            model.ShowAddress = true; // dbContactProfileModel.ShowAddress;
            model.ShowAlternateEmail = true; // dbContactProfileModel.ShowAlternateEmail;
            model.ShowAlternatePhone = true; // dbContactProfileModel.ShowAlternatePhone;
            model.ShowAvailableForWorkMessage = true; // dbContactProfileModel.ShowAvailableForWork;
            model.ShowCurrentlyWorkingOnMessage = true; // dbContactProfileModel.ShowCurrentlyWorkingOnMessage;
            model.ShowGitHubProfile = true; // dbContactProfileModel.ShowGitHubProfile;
            model.ShowHireByMessage = true; // dbContactProfileModel.ShowHireByMessage;
            model.ShowLinkInProfile = true; // dbContactProfileModel.ShowLinkInProfile;
            model.ShowPersonalWebsite = true; // dbContactProfileModel.ShowPersonalWebsite;
            model.ShowPrimaryEmail = true; // dbContactProfileModel.ShowPrimaryEmail;
            model.ShowPrimaryPhone = true; // dbContactProfileModel.ShowPrimaryPhone;
            model.ShowProfilePhoto = true; // dbContactProfileModel.ShowProfilePhoto;
            model.State = dbContactProfileModel.USAState;
            model.UserFirstName = dbContactProfileModel.FirstName;
            model.UserLastName = dbContactProfileModel.LastName;
            model.Zip = dbContactProfileModel.PostalCode;



            // Below is fake Data            
            //model.Address = "123 W. 4th Street";
            //model.AlternateEmail = "bob@google.com";
            //model.AlternatePhone = "414-232-5139";
            //model.AvailableForWorkMessage = "I am looking for work doing Machine Learning.";
            //model.City = "Milwaukee";
            //model.Country = "USA";
            //model.CurrentlyWorkingOnMessage = "I am currently working on a project for McDonalds, order number 16, Fries and a BigMac.";
            //model.GitHubProfile = "http://www.GitHub.com/mkohlmann-he";
            //model.HireByMessage = "I have not been hired yet";
            //model.LinkInProfile = "http://www.linkedin.com/5/14/blahblah";
            //model.PersonalWebsite = "http://www.PersonWebsite.Com";
            //model.PrimaryEmail = "mkohlmann_he@dev.bse.edu";
            //model.PrimaryPhone = "414-pri-mary";
            //model.ProfilePhoto = null;
            //model.ProjectSpotLightObjectList = new List<ProjectSpotLightViewModels>();
            //model.ResumeHtmlUpload = db.UserResumes.FirstOrDefault(dbContactModel => dbContactModel.ProfileID == 2); //== id);
            //model.ShowAddress = true;
            //model.ShowAlternateEmail = true;
            //model.ShowAlternatePhone = true;
            //model.ShowAvailableForWorkMessage = true;
            //model.ShowCurrentlyWorkingOnMessage = true;
            //model.ShowGitHubProfile = true;
            //model.ShowHireByMessage = true;
            //model.ShowLinkInProfile = true;
            //model.ShowPersonalWebsite = true;
            //model.ShowPrimaryEmail = true;
            //model.ShowPrimaryPhone = true;
            //model.ShowProfilePhoto = true;
            //model.State = "WI";
            //model.UserFirstName = "Bob";
            //model.UserLastName = "Smith";
            //model.Zip = "53211";

            ProjectSpotLightViewModels project = new ProjectSpotLightViewModels();
            project.DevelopementTime = 4;
            project.GitHubProfile = "http://www.GitHub.Com/SomeUser/SomeProject";
            project.ProfileID = 1;
            project.ProjectDescription = "Asteroids";
            project.ProjectID = 1;
            project.ProjectImage1 = null;
            project.ProjectImage2 = null;
            project.TeamMembers = null;
            project.Technologies = new List<string>();
            project.Technologies.Add("Python");
            project.Technologies.Add("PyGame");
            project.Technologies.Add("git-Hub");



            model.ProjectSpotLightObjectList = new List<ProjectSpotLightViewModels>();
            model.ResumeHtmlUpload = db.UserResumes.FirstOrDefault(i => i.ProfileID == 2); //== id);
            
            model.ProjectSpotLightObjectList.Add(project);



            return View(model);
        }

        

       



 




    }
}
