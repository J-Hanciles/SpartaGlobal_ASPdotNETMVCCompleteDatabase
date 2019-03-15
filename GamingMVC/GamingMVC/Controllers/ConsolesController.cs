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
    public class ConsolesController : Controller
    {
        private GamingEntities db = new GamingEntities();

        // GET: Consoles
        public ActionResult Index()
        {
            var consoles = db.Consoles.Include(c => c.Company).Include(c => c.Game);
            return View(consoles.ToList());
        }

        // GET: Consoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Console console = db.Consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // GET: Consoles/Create
        public ActionResult Create()
        {
            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName");
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType");
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consoleID,consoleName,consoleVersion,predecessor,successor,price,info,top3Titles,gameID,companyID")] Console console)
        {
            if (ModelState.IsValid)
            {
                db.Consoles.Add(console);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName", console.companyID);
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", console.gameID);
            return View(console);
        }

        // GET: Consoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Console console = db.Consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName", console.companyID);
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", console.gameID);
            return View(console);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consoleID,consoleName,consoleVersion,predecessor,successor,price,info,top3Titles,gameID,companyID")] Console console)
        {
            if (ModelState.IsValid)
            {
                db.Entry(console).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName", console.companyID);
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", console.gameID);
            return View(console);
        }

        // GET: Consoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Console console = db.Consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Console console = db.Consoles.Find(id);
            db.Consoles.Remove(console);
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
