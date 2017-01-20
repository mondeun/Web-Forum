using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Models;
using Web_Forum.Helpers;


namespace Web_Forum.Controllers
{
    public class HomeController : Controller
    {
        public IRepository repo = new Repository();
        public ActionResult Index()
        {

            var threads = new List<IndexThreadViewModel>();
            threads.Transform(repo.GetThreads());
            return View(threads);
        }

        [HttpGet]
        public ActionResult AddThread()
        {
            // TODO Add logic here

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddThread(ThreadViewModel thread)
        {
            if (ModelState.IsValid)
            { 
                repo.AddThread(thread.Transform());

                return View("Index");
            }

            return PartialView(thread);
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