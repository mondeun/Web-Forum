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
        private readonly IRepository _repo = new Repository();
        // GET: Thread
        public ActionResult Index(Guid id)
        {
            //var posts = repo.GetPosts(id).ForEach(x => x.Transform());

            //var threads = new List<IndexThreadViewModel>();
            //threads.Transform(repo.GetThreads());

            var posts = new List<PostViewModel>();
            posts.Transform(_repo.GetPosts(id));
            ViewBag.threadTitle = _repo.GetThreadById(id).Title;
            ViewBag.Likes = _repo.GetLikes(id);
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
                _repo.AddPost(post.Transform());
                var posts = new List<PostViewModel>();
                posts.Transform(_repo.GetPosts(post.ThreadId));
                ViewBag.Likes = _repo.GetLikes(post.ThreadId);
                return PartialView("Index", posts);
            }

            return PartialView(post);
        }

        [HttpPost]
        public ActionResult AddLike(Guid id)
        {
            var likesAmount = _repo.UpdateLikes(id);

            var posts = new List<PostViewModel>();
            posts.Transform(_repo.GetPosts(id));
            return PartialView("AddLike", likesAmount);
        }
        [HttpPost]
        public ActionResult AddPostLike(Guid id)
        {
            var likesAmount = _repo.UpdatePostLikes(id);

            var posts = new List<PostViewModel>();
            posts.Transform(_repo.GetPosts(id));

            return PartialView("AddLike", likesAmount);
        }
        [HttpPost]
        public ActionResult DeletePost(Guid id)
        {

            _repo.DeletePost(id);
            var posts = new List<PostViewModel>();
            posts.Transform(_repo.GetPosts());

            return PartialView("Index", posts);


        }
        [HttpPost]
        public ActionResult EditPost(PostViewModel postToEdit)
        {
            _repo.EditPost(postToEdit.Transform());

            var posts = new List<PostViewModel>();
            posts.Transform(_repo.GetPosts());
            return PartialView("Index", posts);
        }
    }
}