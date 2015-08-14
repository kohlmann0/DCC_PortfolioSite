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


                // Pull resume from database
                model.ResumeHtmlUpload = db.UserResumes.FirstOrDefault(i => i.ProfileID == id);


                // Debug -- Generate a Project spotlight for testing
                ProjectSpotlight project = new ProjectSpotlight();
                project.DevelopmentTime = "200";
                project.RepoLink = "http://www.GitHub.Com/SomeUser/SomeProject";
                project.ProfileID = 1;
                project.ProjectDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tincidunt massa ac augue facilisis, sit amet pharetra lorem molestie. Sed pharetra libero pharetra blandit tincidunt. In nec consequat magna. Etiam id mi lacus. Proin molestie vel nulla eget vulputate. In urna arcu, imperdiet at felis a, lacinia ornare purus. Mauris et vulputate risus. Aenean condimentum non lacus et varius. Phasellus cursus non purus quis scelerisque. Maecenas scelerisque porta nunc, porttitor luctus leo sodales commodo. Ut ultrices mattis dignissim. Aliquam luctus aliquet turpis vitae venenatis.\n\nUt rutrum elit sit amet varius molestie. In at purus eget metus feugiat feugiat vel vel ex. Donec ex nibh, tristique sed nulla at, egestas vulputate nisl. Ut eros urna, placerat id felis sit amet, accumsan ullamcorper nibh. Pellentesque dignissim dolor a rutrum pulvinar. Nulla ut ex metus. Vivamus odio nunc, cursus in euismod ut, congue eget metus. Nulla ante erat, ornare ut porttitor sit amet, imperdiet a eros. Phasellus nec tellus dignissim neque consequat aliquam nec non purus. Curabitur pellentesque pellentesque tortor, fermentum elementum lectus pellentesque in. Curabitur eu laoreet tortor, eu commodo mi. Sed tincidunt iaculis nisi, sed sodales magna facilisis a. Cras vel pellentesque lorem, quis venenatis nisi. Cras varius lacus sed pellentesque efficitur.";
                project.ProjectSpotlightID = -5;
                project.Image_1 = null;
                project.Image_2 = null;
                project.ProjectName = "Asteroids";
                project.TeamMembers = null;
                project.Technologies = "Python, PyGame, Git-Hub";


                // Generate Project List
                List<ProjectSpotlight> dbProjectList = db.ProjectSpotlights.Where(p => p.ProfileID == id).ToList();
                model.ProjectSpotLightObjectList = new List<ProjectSpotlight>();
                foreach (ProjectSpotlight projectItem in dbProjectList)
                {
                    model.ProjectSpotLightObjectList.Add(projectItem);
                }
                model.ProjectSpotLightObjectList.Add(project);



                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        

       



 




    }
}
