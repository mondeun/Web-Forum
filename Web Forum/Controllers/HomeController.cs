using System.Collections.Generic;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Models;
using Web_Forum.Helpers;
using System;

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

            var threads = new List<IndexThreadViewModel>();
            threads.Transform(_repo.GetThreads());
            return View(threads);
        }

        [HttpGet]
        public ActionResult AddThread()
        {
            var thread = new ThreadViewModel();

            return PartialView(thread);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddThread(ThreadViewModel thread)
        {
            if (ModelState.IsValid)
            { 
                _repo.AddThread(thread.Transform());

                var threads = new List<IndexThreadViewModel>();
                threads.Transform(_repo.GetThreads());
                return PartialView("Index", threads);
            }
            

            return PartialView("AddThread",thread);
        }

        [HttpGet]
        public ActionResult EditThread(Guid id)
        {
            var thread = Helper.IndexThreadDtoToViewModel(_repo.GetThreadById(id));

            return PartialView(thread);
        }

        [HttpPost]
        public ActionResult EditThread(IndexThreadViewModel threadToEdit)
        {           
            _repo.EditThread(threadToEdit.Transform());

            var threads = new List<IndexThreadViewModel>();
            threads.Transform(_repo.GetThreads());
            return PartialView("Index", threads);
        }
       
        public ActionResult DeleteThread(Guid id)
        {
            
            _repo.DeleteThread(id);
            var threads = new List<IndexThreadViewModel>();
            threads.Transform(_repo.GetThreads());
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