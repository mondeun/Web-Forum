using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Forum.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread
        public ActionResult Index()
        {
            return View();
        }
    }
}