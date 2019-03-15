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
    public class ConsoleGameDevelopersController : Controller
    {
        private GamingEntities db = new GamingEntities();

        // GET: ConsoleGameDevelopers
        public ActionResult Index()
        {
            var consoleGameDevelopers = db.ConsoleGameDevelopers.Include(c => c.Game);
            return View(consoleGameDevelopers.ToList());
        }

        // GET: ConsoleGameDevelopers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleGameDeveloper consoleGameDeveloper = db.ConsoleGameDevelopers.Find(id);
            if (consoleGameDeveloper == null)
            {
                return HttpNotFound();
            }
            return View(consoleGameDeveloper);
        }

        // GET: ConsoleGameDevelopers/Create
        public ActionResult Create()
        {
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType");
            return View();
        }

        // POST: ConsoleGameDevelopers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consoleGameDeveloperID,stationaryname,price,supplier,gameID")] ConsoleGameDeveloper consoleGameDeveloper)
        {
            if (ModelState.IsValid)
            {
                db.ConsoleGameDevelopers.Add(consoleGameDeveloper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", consoleGameDeveloper.gameID);
            return View(consoleGameDeveloper);
        }

        // GET: ConsoleGameDevelopers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleGameDeveloper consoleGameDeveloper = db.ConsoleGameDevelopers.Find(id);
            if (consoleGameDeveloper == null)
            {
                return HttpNotFound();
            }
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", consoleGameDeveloper.gameID);
            return View(consoleGameDeveloper);
        }

        // POST: ConsoleGameDevelopers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consoleGameDeveloperID,stationaryname,price,supplier,gameID")] ConsoleGameDeveloper consoleGameDeveloper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consoleGameDeveloper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", consoleGameDeveloper.gameID);
            return View(consoleGameDeveloper);
        }

        // GET: ConsoleGameDevelopers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleGameDeveloper consoleGameDeveloper = db.ConsoleGameDevelopers.Find(id);
            if (consoleGameDeveloper == null)
            {
                return HttpNotFound();
            }
            return View(consoleGameDeveloper);
        }

        // POST: ConsoleGameDevelopers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsoleGameDeveloper consoleGameDeveloper = db.ConsoleGameDevelopers.Find(id);
            db.ConsoleGameDevelopers.Remove(consoleGameDeveloper);
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
