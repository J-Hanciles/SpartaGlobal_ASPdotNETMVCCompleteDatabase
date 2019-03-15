using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamingMVC.Controllers
{
    public class BoardGamingController : Controller
    {
        // GET: BoardGaming
        public ActionResult Index()
        {
            return View();
        }
        // Board Game History
        public ActionResult History()
        {
            return View();
        }
        // Types of Games
        public ActionResult Types()
        {
            return View();
        }
        // Games
        public ActionResult Games()
        {
            return View();
        }
    }
}