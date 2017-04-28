using System;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Models;
using Web_Forum.Helpers;

namespace Web_Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController()
        {
            _repo = new Repository();
        }

        public ActionResult Index()
        {
            return View(ThreadHelper.Transform(_repo.GetThreads()));
        }

        [HttpGet]
        public ActionResult AddThread()
        {
            return PartialView(new ThreadViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddThread(ThreadViewModel thread)
        {
            if (ModelState.IsValid)
            { 
                _repo.AddThread(ThreadHelper.Transform(thread));

                return PartialView("Index", ThreadHelper.Transform(_repo.GetThreads()));
            }
            return PartialView("AddThread",thread);
        }

        [HttpGet]
        public ActionResult EditThread(Guid id)
        {
            return PartialView(ThreadHelper.Transform(_repo.GetThreadById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditThread(IndexThreadViewModel threadToEdit)
        {           
            _repo.EditThread(ThreadHelper.Transform(threadToEdit));

            return PartialView("Index", ThreadHelper.Transform(_repo.GetThreads()));
        }
       
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteThread(Guid id)
        {
            _repo.DeleteThread(id);

            return RedirectToActionPermanent("Index");
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