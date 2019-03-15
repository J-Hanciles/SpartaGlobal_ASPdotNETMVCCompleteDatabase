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
    public class ConsoleGamesController : Controller
    {
        private GamingEntities db = new GamingEntities();

        // GET: ConsoleGames
        public ActionResult Index()
        {
            var consoleGames = db.ConsoleGames.Include(c => c.Console).Include(c => c.Game);
            return View(consoleGames.ToList());
        }

        // GET: ConsoleGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleGame consoleGame = db.ConsoleGames.Find(id);
            if (consoleGame == null)
            {
                return HttpNotFound();
            }
            return View(consoleGame);
        }

        // GET: ConsoleGames/Create
        public ActionResult Create()
        {
            ViewBag.consoleID = new SelectList(db.Consoles, "consoleID", "consoleName");
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType");
            return View();
        }

        // POST: ConsoleGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consoleGameID,title,ESRB,genre,playType,releaseDate,price,gameID,consoleID")] ConsoleGame consoleGame)
        {
            if (ModelState.IsValid)
            {
                db.ConsoleGames.Add(consoleGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consoleID = new SelectList(db.Consoles, "consoleID", "consoleName", consoleGame.consoleID);
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", consoleGame.gameID);
            return View(consoleGame);
        }

        // GET: ConsoleGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleGame consoleGame = db.ConsoleGames.Find(id);
            if (consoleGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.consoleID = new SelectList(db.Consoles, "consoleID", "consoleName", consoleGame.consoleID);
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", consoleGame.gameID);
            return View(consoleGame);
        }

        // POST: ConsoleGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consoleGameID,title,ESRB,genre,playType,releaseDate,price,gameID,consoleID")] ConsoleGame consoleGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consoleGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consoleID = new SelectList(db.Consoles, "consoleID", "consoleName", consoleGame.consoleID);
            ViewBag.gameID = new SelectList(db.Games, "gameID", "gameType", consoleGame.gameID);
            return View(consoleGame);
        }

        // GET: ConsoleGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsoleGame consoleGame = db.ConsoleGames.Find(id);
            if (consoleGame == null)
            {
                return HttpNotFound();
            }
            return View(consoleGame);
        }

        // POST: ConsoleGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsoleGame consoleGame = db.ConsoleGames.Find(id);
            db.ConsoleGames.Remove(consoleGame);
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
