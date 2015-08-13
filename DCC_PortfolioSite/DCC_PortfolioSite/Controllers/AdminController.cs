using DCC_PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCC_PortfolioSite.Controllers
{
    public class AdminController : Controller
    {

        AlumniDBModel db = new AlumniDBModel();

        // SAVE PROFILE
        [HttpPost]
        public ActionResult SaveProfile(AdminViewModel model)
        {
            string connectionStringDB = "Server=tcp:wx9a1lruht.database.windows.net,1433;Database=DCCPortfolioSite_db;User ID=devcodecamp;Password=heliumdev1!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionStringDB))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("UPDATE ContactProfile SET FirstName = @fName, LastName = @lName, BirthDate = @bDate, PrimaryPhone = @pPhone, AlternatePhone = @aPhone, StreetAddress = @sAddress, City = @city, USAState = @usaState, Country = @country, PostalCode = @pCode, About = @about, Photo = @photo, LinkedIn = @lIn, GitHub = @gHub, PersonalWebsite = @pWebSite, AvailableForWork = @aForWork, HiredBy = @hBy, CurrentWork = @cWork WHERE PrimaryEmail = @fNameUser");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("@fName", (String.IsNullOrEmpty(model.ContactProfile.FirstName)) ? " " : model.ContactProfile.FirstName) ;
                cmd.Parameters.AddWithValue("@lName", (String.IsNullOrEmpty(model.ContactProfile.LastName)) ? " " : model.ContactProfile.LastName);
                cmd.Parameters.AddWithValue("@bDate", (DateTime.Equals(model.ContactProfile.BirthDate, null)) ? Convert.ToDateTime("01/01/1900") : model.ContactProfile.BirthDate);
                cmd.Parameters.AddWithValue("@pPhone", (String.IsNullOrEmpty(model.ContactProfile.PrimaryPhone)) ? " " : model.ContactProfile.PrimaryPhone);
                cmd.Parameters.AddWithValue("@aPhone", (String.IsNullOrEmpty(model.ContactProfile.AlternatePhone)) ? " " : model.ContactProfile.AlternatePhone);
                cmd.Parameters.AddWithValue("@pEmail", (String.IsNullOrEmpty(model.ContactProfile.PrimaryEmail)) ? " " : model.ContactProfile.PrimaryEmail);
                cmd.Parameters.AddWithValue("@aEmail", (String.IsNullOrEmpty(model.ContactProfile.AlternateEmail)) ? " " : model.ContactProfile.AlternateEmail);
                cmd.Parameters.AddWithValue("@sAddress", (String.IsNullOrEmpty(model.ContactProfile.StreetAddress)) ? " " : model.ContactProfile.StreetAddress);
                cmd.Parameters.AddWithValue("@city", (String.IsNullOrEmpty(model.ContactProfile.City)) ? " " : model.ContactProfile.City);
                cmd.Parameters.AddWithValue("@usaState", (String.IsNullOrEmpty(model.ContactProfile.USAState)) ? " " : model.ContactProfile.USAState);
                cmd.Parameters.AddWithValue("@country", (String.IsNullOrEmpty(model.ContactProfile.Country)) ? " " : model.ContactProfile.Country);
                cmd.Parameters.AddWithValue("@pCode", (int.Equals(model.ContactProfile.PostalCode, null)) ? 0 : model.ContactProfile.PostalCode);
                cmd.Parameters.AddWithValue("@about", (String.IsNullOrEmpty(model.ContactProfile.About)) ? " " : model.ContactProfile.About);
                cmd.Parameters.AddWithValue("@photo", (String.IsNullOrEmpty(model.ContactProfile.Photo)) ? " " : model.ContactProfile.Photo);
                cmd.Parameters.AddWithValue("@lIn", (String.IsNullOrEmpty(model.ContactProfile.LinkedIn)) ? " " : model.ContactProfile.LinkedIn);
                cmd.Parameters.AddWithValue("@gHub", (String.IsNullOrEmpty(model.ContactProfile.GitHub)) ? " " : model.ContactProfile.GitHub);
                cmd.Parameters.AddWithValue("@pWebsite", (String.IsNullOrEmpty(model.ContactProfile.PersonalWebsite)) ? " " : model.ContactProfile.PersonalWebsite);
                cmd.Parameters.AddWithValue("@aForWork", (bool.Equals(model.ContactProfile.AvailableForWork, null)) ? true : model.ContactProfile.AvailableForWork);
                cmd.Parameters.AddWithValue("@hBy", (String.IsNullOrEmpty(model.ContactProfile.HiredBy)) ? " " : model.ContactProfile.HiredBy);
                cmd.Parameters.AddWithValue("@cWork", (String.IsNullOrEmpty(model.ContactProfile.CurrentWork)) ? " " : model.ContactProfile.CurrentWork);
                
                cmd.Parameters.AddWithValue("@fNameUser", User.Identity.Name);

                cmd.ExecuteNonQuery();

            }

            return RedirectToAction("Index", "Admin");
        }

        // SAVE PROJECT
        [HttpPost]
        public ActionResult SaveProject(AdminViewModel model)
        {
            string connectionStringDB = "Server=tcp:wx9a1lruht.database.windows.net,1433;Database=DCCPortfolioSite_db;User ID=devcodecamp;Password=heliumdev1!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionStringDB))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("UPDATE ContactProfile SET ProjectName = @pName, Technologies = @tech, DevelopmentTime = @dTime, ProjectDescription = @pDescrip, RepoLink = @rLink, Image_1 = @i1, Image_2 = @i2 WHERE PrimaryEmail = @fNameUser");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("@pName", (String.IsNullOrEmpty(model.ProjectSpotlight.ProjectName)) ? " " : model.ProjectSpotlight.ProjectName);
                cmd.Parameters.AddWithValue("@tech", (String.IsNullOrEmpty(model.ProjectSpotlight.Technologies)) ? " " : model.ProjectSpotlight.Technologies);
                cmd.Parameters.AddWithValue("@dTime", (String.IsNullOrEmpty(model.ProjectSpotlight.DevelopmentTime)) ? " " : model.ProjectSpotlight.DevelopmentTime);
                cmd.Parameters.AddWithValue("@pDescrip", (String.IsNullOrEmpty(model.ProjectSpotlight.ProjectDescription)) ? " " : model.ProjectSpotlight.ProjectDescription);
                cmd.Parameters.AddWithValue("@rLink", (String.IsNullOrEmpty(model.ProjectSpotlight.RepoLink)) ? " " : model.ProjectSpotlight.RepoLink);
                cmd.Parameters.AddWithValue("@i1", (String.IsNullOrEmpty(model.ProjectSpotlight.Image_1)) ? " " : model.ProjectSpotlight.Image_1);
                cmd.Parameters.AddWithValue("@i2", (String.IsNullOrEmpty(model.ProjectSpotlight.Image_2)) ? " " : model.ProjectSpotlight.Image_2);

                cmd.Parameters.AddWithValue("@fNameUser", User.Identity.Name);

                cmd.ExecuteNonQuery();

            }

            return RedirectToAction("Index", "Admin");
        }

        // GET: Admin
        public ActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();

            string UserID = User.Identity.Name;

            
            adminViewModel.ContactProfile = db.ContactProfiles.FirstOrDefault(p => p.PrimaryEmail == UserID);
            adminViewModel.UserResume = db.UserResumes.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            adminViewModel.ProjectSpotlight = db.ProjectSpotlights.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            
            //adminViewModel.UserProfile = db.UserProfiles.FirstOrDefault(p => p.UserID == 2);
            //adminViewModel.ContactProfile = db.ContactProfiles.FirstOrDefault(p => p.ProfileId == 2);
            //adminViewModel.UserResume = db.UserResumes.FirstOrDefault(p => p.UserResumeID == 2);
            //adminViewModel.ProjectSpotlight = db.ProjectSpotlights.FirstOrDefault(p => p.ProjectSpotlightID == 3);

            return View(adminViewModel);
        }

        // REDIRECT: to Edit page
        public ActionResult Edit()
        {
            AdminViewModel adminViewModel = new AdminViewModel();

            string UserID = User.Identity.Name;


            adminViewModel.ContactProfile = db.ContactProfiles.FirstOrDefault(p => p.PrimaryEmail == UserID);
            adminViewModel.UserResume = db.UserResumes.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            adminViewModel.ProjectSpotlight = db.ProjectSpotlights.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            
            return View("Index_Edit", adminViewModel);
        }

        // GET: Resume
        public ActionResult Resume()
        {
            UserResume results = db.UserResumes.FirstOrDefault(r => r.ProfileID == 2);
                            

            return View("Resume", results);
        }


    }
}