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
    public class UserResume_auto_Controller : Controller
    {
        private AlumniDBModel db = new AlumniDBModel();

        // GET: UserResume_auto_
        public ActionResult Index()
        {
            var userResumes = db.UserResumes.Include(u => u.ContactProfile);
            return View(userResumes.ToList());
        }

        // GET: UserResume_auto_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResume userResume = db.UserResumes.Find(id);
            if (userResume == null)
            {
                return HttpNotFound();
            }
            return View(userResume);
        }

        // GET: UserResume_auto_/Create
        public ActionResult Create()
        {
            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName");
            return View();
        }

        // POST: UserResume_auto_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserResumeID,ProfileID,HtmlUpload")] UserResume userResume)
        {
            if (ModelState.IsValid)
            {
                db.UserResumes.Add(userResume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName", userResume.ProfileID);
            return View(userResume);
        }

        // GET: UserResume_auto_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResume userResume = db.UserResumes.Find(id);
            if (userResume == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName", userResume.ProfileID);
            return View(userResume);
        }

        // POST: UserResume_auto_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserResumeID,ProfileID,HtmlUpload")] UserResume userResume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userResume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileID = new SelectList(db.ContactProfiles, "ProfileId", "FirstName", userResume.ProfileID);
            return View(userResume);
        }

        // GET: UserResume_auto_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResume userResume = db.UserResumes.Find(id);
            if (userResume == null)
            {
                return HttpNotFound();
            }
            return View(userResume);
        }

        // POST: UserResume_auto_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserResume userResume = db.UserResumes.Find(id);
            db.UserResumes.Remove(userResume);
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
