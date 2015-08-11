using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCC_PortfolioSite.Models;

namespace DCC_PortfolioSite.Controllers
{
    public class ProjectSpotlight_auto_Controller : Controller
    {
        private AlumniDBModel db = new AlumniDBModel();

        // GET: ProjectSpotlight_auto_
        public ActionResult Index()
        {
            var projectSpotlights = db.ProjectSpotlights.Include(p => p.ContactProfile);
            return View(projectSpotlights.ToList());
        }

        // GET: ProjectSpotlight_auto_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSpotlight projectSpotlight = db.ProjectSpotlights.Find(id);
            if (projectSpotlight == null)
            {
                return HttpNotFound();
            }
            return View(projectSpotlight);
        }

        // GET: ProjectSpotlight_auto_/Create
        public ActionResult Create()
        {
            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName");
            return View();
        }

        // POST: ProjectSpotlight_auto_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectSpotlightID,ProfileID,ProjectName,Technologies,DevelopmentTime,ProjectDescription,RepoLink,Image_1,Image_2")] ProjectSpotlight projectSpotlight)
        {
            if (ModelState.IsValid)
            {
                db.ProjectSpotlights.Add(projectSpotlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName", projectSpotlight.ProfileID);
            return View(projectSpotlight);
        }

        // GET: ProjectSpotlight_auto_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSpotlight projectSpotlight = db.ProjectSpotlights.Find(id);
            if (projectSpotlight == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName", projectSpotlight.ProfileID);
            return View(projectSpotlight);
        }

        // POST: ProjectSpotlight_auto_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectSpotlightID,ProfileID,ProjectName,Technologies,DevelopmentTime,ProjectDescription,RepoLink,Image_1,Image_2")] ProjectSpotlight projectSpotlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectSpotlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName", projectSpotlight.ProfileID);
            return View(projectSpotlight);
        }

        // GET: ProjectSpotlight_auto_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSpotlight projectSpotlight = db.ProjectSpotlights.Find(id);
            if (projectSpotlight == null)
            {
                return HttpNotFound();
            }
            return View(projectSpotlight);
        }

        // POST: ProjectSpotlight_auto_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectSpotlight projectSpotlight = db.ProjectSpotlights.Find(id);
            db.ProjectSpotlights.Remove(projectSpotlight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
