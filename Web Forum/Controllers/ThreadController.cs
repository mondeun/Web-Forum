using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Models;
using Web_Forum.data.Repositories;
using Web_Forum.Helpers;
using Web_Forum.Models;
using Web_Forum.Helpers;

namespace Web_Forum.Controllers
{
    public class ThreadController : Controller
    {
        private IRepository repo = new DummyRepository();
        // GET: Thread
        public ActionResult Index(Guid id)
        {
            var posts = repo.GetPosts(id).ForEach(x => x.Transform());
            return View(posts);
        }

        [HttpGet]
        public ActionResult AddPost(Guid threadId)
        {
            // TODO Add logic here

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(PostViewModel post)
        {
            //TODO Add logic here
            if (ModelState.IsValid)
            {
                repo.AddPost(post.Transform());

                return RedirectToAction("Index", post.ThreadId);
            }

            return View(post);
        }
       
    }
}