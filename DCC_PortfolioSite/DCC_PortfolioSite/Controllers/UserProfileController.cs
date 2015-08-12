﻿using DCC_PortfolioSite.Models;
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



            // Debug -- Force everything to show            
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
            model.ShowResume = true;


            // Debug -- Generate a Project spotlight for testing
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
            model.ProjectSpotLightObjectList.Add(project);

            // Pull resume from database
            model.ResumeHtmlUpload = db.UserResumes.FirstOrDefault(i => i.ProfileID == id);

            return View(model);
        }

        

       



 




    }
}
