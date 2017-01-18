using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data;

namespace Web_Forum.Controllers
{

    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            return View();
        }
    }
}