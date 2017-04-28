using System;
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
            var thread = _repo.GetThreadById(id);

            ViewBag.threadTitle = thread.Title;
            ViewBag.Likes = thread.Likes;

            return View(PostHelper.Transform(_repo.GetPosts(id)));
        }

        [HttpGet]
        public ActionResult AddPost(Guid id)
        {
            return PartialView(new PostViewModel { ThreadId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                _repo.AddPost(PostHelper.Transform(post));
                ViewBag.Likes = _repo.GetLikes(post.ThreadId);

                return PartialView("Index", PostHelper.Transform(_repo.GetPosts(post.ThreadId)));
            }

            return PartialView(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLike(Guid id)
        {
            return PartialView("AddLike", _repo.UpdateLikes(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPostLike(Guid id)
        {
            return PartialView("AddLike", _repo.UpdatePostLikes(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(Guid id)
        {
            _repo.DeletePost(id);

            return PartialView("Index", PostHelper.Transform(_repo.GetPosts()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(PostViewModel postToEdit)
        {
            _repo.EditPost(PostHelper.Transform(postToEdit));

            return PartialView("Index", PostHelper.Transform(_repo.GetPosts()));
        }
    }
}