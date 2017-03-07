using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Web_Forum.data.Interfaces;
using Web_Forum.data.Repositories;
using Web_Forum.Helpers;
using Web_Forum.Models;

namespace Web_Forum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository _repo = new Repository();

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
                return View(user);

            var dbUser = UserHelper.GetUserViewModelFromDto(_repo.GetUserByCredentials(user.Email, user.Password));

            if (dbUser.Email != null && dbUser.Password != null)
            {
                var identity = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Name, dbUser.Name),
                    new Claim(ClaimTypes.Email, dbUser.Email),
                    new Claim(ClaimTypes.Role, dbUser.IsModerator ? "Mod" : "Guest"), 
                    new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString())
                }, "UserCookie");

                var ctx = Request.GetOwinContext();
                var auth = ctx.Authentication;
                auth.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var auth = ctx.Authentication;

            auth.SignOut("UserCookie");

            return RedirectToAction("Index", "Home");
        }
    }
}