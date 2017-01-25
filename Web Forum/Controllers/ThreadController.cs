using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Helpers;
using Web_Forum.Models;

namespace Web_Forum.Controllers
{
    public class ThreadController : Controller
    {
        private IRepository repo = new Repository();
        // GET: Thread
        public ActionResult Index(Guid id)
        {
            //var posts = repo.GetPosts(id).ForEach(x => x.Transform());

            //var threads = new List<IndexThreadViewModel>();
            //threads.Transform(repo.GetThreads());

            var posts = new List<PostViewModel>();
            posts.Transform(repo.GetPosts(id));
            ViewBag.threadTitle = repo.GetThreadById(id).Title;
            ViewBag.Likes = repo.GetLikes(id);
            return View(posts);
        }

        [HttpGet]
        public ActionResult AddPost(Guid id)
        {
            var post = new PostViewModel { ThreadId = id };

            return PartialView(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                repo.AddPost(post.Transform());

                var posts = new List<PostViewModel>();
                posts.Transform(repo.GetPosts(post.ThreadId));
                return PartialView("Index", posts);
            }

            return PartialView(post);
        }

        [HttpPost]
        public ActionResult AddLike(Guid id)
        {
            repo.UpdateLikes(id);

            var posts = new List<PostViewModel>();
            posts.Transform(repo.GetPosts(id));
            return PartialView("AddLike", posts);
        }

    }
}