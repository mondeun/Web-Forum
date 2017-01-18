using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;

namespace Web_Forum.Controllers
{
    public class SubforumController : Controller
    {
        public IRepository repo = new DummyRepository();
        // GET: Subforum
        public ActionResult Index()
        {
            var subForums = repo.GetSubforums();
            return View(subForums);
        }
    }
}