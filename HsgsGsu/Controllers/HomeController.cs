using HsgsGsu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HsgsGsu.Controllers
{
    public class HomeController : Controller
    {
        private GSUContext db = new GSUContext();

        public ActionResult Index()
        {

            ViewBag.AfgorKarusel = true;
            return View(db.Sjantpics.Select(i => i).Take(3));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}