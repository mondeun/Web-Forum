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
    public class ThreadController : Controller
    {
        private IRepository repo = new DummyRepository();
        // GET: Thread
        public ActionResult Index(Guid id)
        {
            var posts = repo.GetPosts(id);
            return View(posts);
        }

        public ActionResult AddPost()
        {
            // TODO Add logic here

            return View();
        }

        [HttpPost]
        public ActionResult AddThread(PostViewModel thread)
        {
            //TODO Add logic here

            return View("Index");
        }
    }
}