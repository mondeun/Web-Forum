using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Forum.Controllers
{
    public class SubforumController : Controller
    {
        // GET: Subforum
        public ActionResult Index()
        {
            return View();
        }
    }
}