using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamingMVC;

namespace GamingMVC.Controllers
{
    public class GamertagRegistersController : Controller
    {
        private GamingEntities2 db = new GamingEntities2();

        // GET: GamertagRegisters
        public ActionResult Index()
        {
            var gamertagRegisters = db.GamertagRegisters.Include(g => g.Company);
            return View(gamertagRegisters.ToList());
        }

        // GET: GamertagRegisters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamertagRegister gamertagRegister = db.GamertagRegisters.Find(id);
            if (gamertagRegister == null)
            {
                return HttpNotFound();
            }
            return View(gamertagRegister);
        }

        // GET: GamertagRegisters/Create
        public ActionResult Create()
        {
            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName");
            return View();
        }

        // POST: GamertagRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gamertageRegisterID,firstName,lastName,dob,email,confirmEmail,gamertag,companyID")] GamertagRegister gamertagRegister)
        {
            if (ModelState.IsValid)
            {
                db.GamertagRegisters.Add(gamertagRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName", gamertagRegister.companyID);
            return View(gamertagRegister);
        }

        // GET: GamertagRegisters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamertagRegister gamertagRegister = db.GamertagRegisters.Find(id);
            if (gamertagRegister == null)
            {
                return HttpNotFound();
            }
            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName", gamertagRegister.companyID);
            return View(gamertagRegister);
        }

        // POST: GamertagRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gamertageRegisterID,firstName,lastName,dob,email,confirmEmail,gamertag,companyID")] GamertagRegister gamertagRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamertagRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.companyID = new SelectList(db.Companies, "companyID", "companyName", gamertagRegister.companyID);
            return View(gamertagRegister);
        }

        // GET: GamertagRegisters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamertagRegister gamertagRegister = db.GamertagRegisters.Find(id);
            if (gamertagRegister == null)
            {
                return HttpNotFound();
            }
            return View(gamertagRegister);
        }

        // POST: GamertagRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GamertagRegister gamertagRegister = db.GamertagRegisters.Find(id);
            db.GamertagRegisters.Remove(gamertagRegister);
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
