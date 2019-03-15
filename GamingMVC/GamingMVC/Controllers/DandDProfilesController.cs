using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamingMVC.Models;

namespace GamingMVC.Controllers
{
    public class DandDProfilesController : Controller
    {
        private GamingEntities db = new GamingEntities();

        // GET: DandDProfiles
        public ActionResult Index()
        {
            var dandDProfiles = db.DandDProfiles.Include(d => d.Game);
            return View(dandDProfiles.ToList());
        }

        // GET: DandDProfiles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DandDProfile dandDProfile = db.DandDProfiles.Find(id);
            if (dandDProfile == null)
            {
                return HttpNotFound();
            }
            return View(dandDProfile);
        }

        // GET: DandDProfiles/Create
        public ActionResult Create()
        {
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType");
            return View();
        }

        // POST: DandDProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dAndDProfileID,characterName,classAndLevel,race,alignment,playerName,gameID")] DandDProfile dandDProfile)
        {
            if (ModelState.IsValid)
            {
                db.DandDProfiles.Add(dandDProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", dandDProfile.gameID);
            return View(dandDProfile);
        }

        // GET: DandDProfiles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DandDProfile dandDProfile = db.DandDProfiles.Find(id);
            if (dandDProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", dandDProfile.gameID);
            return View(dandDProfile);
        }

        // POST: DandDProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dAndDProfileID,characterName,classAndLevel,race,alignment,playerName,gameID")] DandDProfile dandDProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dandDProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", dandDProfile.gameID);
            return View(dandDProfile);
        }

        // GET: DandDProfiles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DandDProfile dandDProfile = db.DandDProfiles.Find(id);
            if (dandDProfile == null)
            {
                return HttpNotFound();
            }
            return View(dandDProfile);
        }

        // POST: DandDProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DandDProfile dandDProfile = db.DandDProfiles.Find(id);
            db.DandDProfiles.Remove(dandDProfile);
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
