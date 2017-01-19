using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Models;


namespace Web_Forum.Controllers
{
    public class HomeController : Controller
    {
        public IRepository repo = new DummyRepository();
        public ActionResult Index()
        {
            var threads = repo.GetThreads();
            return View(threads);
        }

        [HttpGet]
        public ActionResult AddThread()
        {
            // TODO Add logic here

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddThread(ThreadViewModel thread)
        {
            //TODO Add logic here

            return View("Index");
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