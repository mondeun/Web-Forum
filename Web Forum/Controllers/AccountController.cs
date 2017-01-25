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
    public class AccountController : Controller
    {
        private IRepository repo = new Repository();

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid)
                return PartialView(user);

            var dbUser = new UserViewModel();

            return PartialView(user);
        }
    }
}