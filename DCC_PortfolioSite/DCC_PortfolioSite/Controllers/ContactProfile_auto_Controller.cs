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
    public class ContactProfile_auto_Controller : Controller
    {
        private AlumniDBModel db = new AlumniDBModel();

        // GET: ContactProfile_auto_
        public ActionResult Index()
        {
            var contactProfiles = db.ContactProfiles.Include(c => c.UserProfile);
            return View(contactProfiles.ToList());
        }

        // GET: ContactProfile_auto_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactProfile contactProfile = db.ContactProfiles.Find(id);
            if (contactProfile == null)
            {
                return HttpNotFound();
            }
            return View(contactProfile);
        }

        // GET: ContactProfile_auto_/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserID", "UserName");
            return View();
        }

        // POST: ContactProfile_auto_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,UserId,FirstName,LastName,BirthDate,PrimaryPhone,AlternatePhone,PrimaryEmail,AlternateEmail,StreetAddress,City,USAState,Country,PostalCode,About,Photo,LinkedIn,GitHub,PersonalWebsite,AvailableForWork,HiredBy,CurrentWork")] ContactProfile contactProfile)
        {
            if (ModelState.IsValid)
            {
                db.ContactProfiles.Add(contactProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserID", "UserName", contactProfile.UserId);
            return View(contactProfile);
        }

        // GET: ContactProfile_auto_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactProfile contactProfile = db.ContactProfiles.Find(id);
            if (contactProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserID", "UserName", contactProfile.UserId);
            return View(contactProfile);
        }

        // POST: ContactProfile_auto_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,UserId,FirstName,LastName,BirthDate,PrimaryPhone,AlternatePhone,PrimaryEmail,AlternateEmail,StreetAddress,City,USAState,Country,PostalCode,About,Photo,LinkedIn,GitHub,PersonalWebsite,AvailableForWork,HiredBy,CurrentWork")] ContactProfile contactProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserID", "UserName", contactProfile.UserId);
            return View(contactProfile);
        }

        // GET: ContactProfile_auto_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactProfile contactProfile = db.ContactProfiles.Find(id);
            if (contactProfile == null)
            {
                return HttpNotFound();
            }
            return View(contactProfile);
        }

        // POST: ContactProfile_auto_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactProfile contactProfile = db.ContactProfiles.Find(id);
            db.ContactProfiles.Remove(contactProfile);
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
