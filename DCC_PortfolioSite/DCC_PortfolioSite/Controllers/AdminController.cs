using DCC_PortfolioSite.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        [Authorize]
        public ActionResult SaveProfile(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.ContactProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            string UserID = User.Identity.Name;

            adminViewModel.ContactProfile = db.ContactProfiles.FirstOrDefault(p => p.PrimaryEmail == UserID);
            adminViewModel.UserResume = db.UserResumes.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            adminViewModel.ProjectSpotlight = db.ProjectSpotlights.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            var projects = (from p in db.ProjectSpotlights
                            where p.ContactProfile.PrimaryEmail == UserID
                            select p).ToList();
            adminViewModel.ProjectSpotlightList = projects;

            return View(adminViewModel);
        }

        // REDIRECT: to Edit page
        [Authorize]
        public ActionResult Edit()
        {
            AdminViewModel adminViewModel = new AdminViewModel();

            string UserID = User.Identity.Name;

            adminViewModel.ContactProfile = db.ContactProfiles.FirstOrDefault(p => p.PrimaryEmail == UserID);
            adminViewModel.UserResume = db.UserResumes.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            adminViewModel.ProjectSpotlight = db.ProjectSpotlights.FirstOrDefault(p => p.ContactProfile.PrimaryEmail == UserID);
            var projects = (from p in db.ProjectSpotlights
                            where p.ContactProfile.PrimaryEmail == UserID
                            select p).ToList();
           
            adminViewModel.ProjectSpotlightList = projects;

            return View("Index_Edit", adminViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ImageUploadPhoto()
        {
            var image = Request.Files["image"];
            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
                Stream photoStream = image.InputStream;
                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                    image.FileName, image.ContentType, image.ContentLength);
               

                ContactProfile refreshModel = db.ContactProfiles.FirstOrDefault(r => r.PrimaryEmail == User.Identity.Name);

                byte[] photoBytes;

                using (BinaryReader binaryData = new BinaryReader(photoStream))
                {
                    photoBytes = binaryData.ReadBytes((int)photoStream.Length);//must convert long to int
                }

                refreshModel.Img = photoBytes;
               
                db.Entry(refreshModel).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Edit", "Admin");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ResumeUpload()
        {
            AlumniDBModel db = new AlumniDBModel();
            var image = Request.Files["resume"];

            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
                Stream resumeStream = image.InputStream;

                ContactProfile profileId = (from contact in db.ContactProfiles
                                            where contact.PrimaryEmail == User.Identity.Name
                                            select contact).FirstOrDefault();
                UserResume refreshModel = db.UserResumes.FirstOrDefault(r => r.ProfileID == profileId.ProfileId);
                
                byte[] resumeBytes;

                using (BinaryReader binaryData = new BinaryReader(resumeStream))
                {
                    resumeBytes = binaryData.ReadBytes((int)resumeStream.Length);//must convert long to int
                }

                refreshModel.ResumeImg = resumeBytes;
                db.Entry(refreshModel).State = EntityState.Modified;
                db.SaveChanges();   

            }
            return RedirectToAction("Edit", "Admin");
        }



        // GET: CREATE PROJECT
        [Authorize]
        public ActionResult CreateProject(int ContactID)
        {
            ProjectSpotlight model = new ProjectSpotlight();
            model.ProfileID = ContactID;
            
            return View(model);
        }
        // POST: Save Data
        [HttpPost]
        [Authorize]
        public ActionResult CreateProject(ProjectSpotlight model)
        {
            if (ModelState.IsValid)
            {
                db.ProjectSpotlights.Add(model);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("EditProject", new { ProjectID = model.ProjectSpotlightID });
        }



        // GET: EDIT PROJECT
        [Authorize]
        public ActionResult EditProject(int ProjectID)
        {
            ProjectSpotlight model = db.ProjectSpotlights.FirstOrDefault(r => r.ProjectSpotlightID == ProjectID);
            return View("EditProject", model);
        }
        // POST: Update Project Data
        [HttpPost]
        [Authorize]
        public ActionResult EditProject(ProjectSpotlight model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return View(model);
            }
            else
            {
                return View(model);
            }

            ProjectSpotlight refreshModel = db.ProjectSpotlights.FirstOrDefault(r => r.ProjectSpotlightID == model.ProjectSpotlightID);
            return View("EditProject", refreshModel);
        }

        // POST: Delete Project Data
        [HttpPost]
        [Authorize]
        public ActionResult DeleteProject(int ProjectSpotlightID)
        {
            ProjectSpotlight project = db.ProjectSpotlights.Single(p => p.ProjectSpotlightID == ProjectSpotlightID);
            if (project == null)
                return View("NotFound");

            db.ProjectSpotlights.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Edit", "Admin");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ImageUploadPhotoEdit1(int ProjectSpotlightID)
        {
            var image = Request.Files["image1"];
            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {

                Stream photoStream = image.InputStream;
                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                    image.FileName, image.ContentType, image.ContentLength);

                ContactProfile profileId = (from contact in db.ContactProfiles
                                            where contact.PrimaryEmail == User.Identity.Name
                                            select contact).FirstOrDefault();
                ProjectSpotlight refreshModel = db.ProjectSpotlights.FirstOrDefault(r => r.ProjectSpotlightID == ProjectSpotlightID);
                byte[] photoBytes;

                using (BinaryReader binaryData = new BinaryReader(photoStream))
                {
                    photoBytes = binaryData.ReadBytes((int)photoStream.Length);//must convert long to int
                }

                refreshModel.SpotlightImg_1 = photoBytes;
               
                db.Entry(refreshModel).State = EntityState.Modified;
                db.SaveChanges();
            }
            ProjectSpotlight finalRefreshModel = db.ProjectSpotlights.FirstOrDefault(r => r.ProjectSpotlightID == ProjectSpotlightID);
            return View("EditProject", finalRefreshModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ImageUploadPhotoEdit2(int ProjectSpotlightID)
        {
            var image = Request.Files["image2"];
            if (image == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                    image.FileName, image.ContentType, image.ContentLength);

                Stream photoStream = image.InputStream;

                ContactProfile profileId = (from contact in db.ContactProfiles
                                            where contact.PrimaryEmail == User.Identity.Name
                                            select contact).FirstOrDefault();
                ProjectSpotlight refreshModel = db.ProjectSpotlights.FirstOrDefault(r => r.ProjectSpotlightID == ProjectSpotlightID);
                byte[] photoBytes;

                using (BinaryReader binaryData = new BinaryReader(photoStream))
                {
                    photoBytes = binaryData.ReadBytes((int)photoStream.Length);//must convert long to int
                }

                refreshModel.SpotlightImg_2 = photoBytes;
               
                db.Entry(refreshModel).State = EntityState.Modified;
                db.SaveChanges();


            }
            ProjectSpotlight finalRefreshModel = db.ProjectSpotlights.FirstOrDefault(r => r.ProjectSpotlightID == ProjectSpotlightID);

            return View("EditProject", finalRefreshModel);
        }
    }
}