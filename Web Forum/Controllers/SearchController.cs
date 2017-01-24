using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Helpers;
using Web_Forum.Models;

namespace Web_Forum.Controllers
{
    public class SearchController : Controller
    {
        private IRepository repo = new Repository();

        // GET: Search
        public ActionResult Results(string search)
        {
            var results = new SearchViewModel();

            results.Threads.Transform(repo.SearchThreads(search));
            results.Posts.Transform(repo.SearchPosts(search));

            return View(results);
        }
    }
}