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
            try
            {
                // Copy over Data
                model.About = dbContactProfileModel.About;
                model.Address = dbContactProfileModel.StreetAddress;
                model.AlternateEmail = dbContactProfileModel.AlternateEmail;
                model.AlternatePhone = dbContactProfileModel.AlternatePhone;
                model.AvailableForWorkMessage = ""; // dbContactProfileModel.AvailableForWorkMessage;
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
                model.ShowAddress = dbContactProfileModel.ShowAddress;
                model.ShowAlternateEmail = dbContactProfileModel.ShowAlternateEmail;
                model.ShowAlternatePhone = dbContactProfileModel.ShowAlternatePhone;
                model.ShowAvailableForWorkMessage = dbContactProfileModel.ShowAvailableForWork;
                model.ShowCurrentlyWorkingOnMessage = dbContactProfileModel.ShowCurrentlyWorking;
                model.ShowGitHubProfile = dbContactProfileModel.ShowGitHubLink;
                model.ShowHireByMessage = dbContactProfileModel.ShowHireByMessage;
                model.ShowLinkInProfile = dbContactProfileModel.ShowLinkedInLink;
                model.ShowPersonalWebsite = dbContactProfileModel.ShowPersonalWebsiteLink;
                model.ShowPrimaryEmail = dbContactProfileModel.ShowPrimaryEmail;
                model.ShowPrimaryPhone = dbContactProfileModel.ShowPrimaryPhone;
                model.ShowProfilePhoto = dbContactProfileModel.ShowProfilePhoto;
                model.ShowResume = true; // dbContactProfileModel.ShowResume;
                model.State = dbContactProfileModel.USAState;
                model.UserFirstName = dbContactProfileModel.FirstName;
                model.UserLastName = dbContactProfileModel.LastName;
                model.Zip = dbContactProfileModel.PostalCode;

                // Generate Project List
                List<ProjectSpotlight> dbProjectList = db.ProjectSpotlights.Where(p => p.ProfileID == id).ToList();
                model.ProjectSpotLightObjectList = new List<ProjectSpotlight>();
                foreach (ProjectSpotlight projectItem in dbProjectList)
                {
                    model.ProjectSpotLightObjectList.Add(projectItem);
                }


                // Pull resume from database
                model.ResumeHtmlUpload = db.UserResumes.FirstOrDefault(i => i.ProfileID == id);

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }



        public ActionResult GetImg(int ResumeId)
        {
            UserResume resume = db.UserResumes.Single(r => r.UserResumeID == ResumeId);
            if (resume != null & resume.ResumeImg != null)
            {
                return new FileContentResult(resume.ResumeImg, "image/png");
            }
            return null;
        }

        public ActionResult GetProjectImg1(int ProjectId)
        {
            ProjectSpotlight project = db.ProjectSpotlights.Single(p => p.ProjectSpotlightID == ProjectId);
            if (project != null & project.SpotlightImg_1 != null)
            {
                return new FileContentResult(project.SpotlightImg_1, "image/png");
            }
            return null;
        }

        public ActionResult GetProjectImg2(int ProjectId)
        {
            ProjectSpotlight project = db.ProjectSpotlights.Single(p => p.ProjectSpotlightID == ProjectId);
            if (project != null & project.SpotlightImg_2 != null)
            {
                return new FileContentResult(project.SpotlightImg_2, "image/png");
            }
            return null;
        }

    }
}
