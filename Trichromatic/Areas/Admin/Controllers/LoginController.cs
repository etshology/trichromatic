using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Trichromatic.Models;

namespace Trichromatic.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private TrichromaticEntities db = new TrichromaticEntities();

        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(User u)
        {
            var user = db.Users.Where(x => x.Username == u.Username && x.Password == u.Password && u.Active == true);
            if (user.Count() > 0)
            {
                //insert cookie
                FormsAuthentication.SetAuthCookie(u.Username, true);
                return RedirectToAction("Index", "Slider", new { area = "Backend" });
            }
            else
            {
                ViewBag.Failed = true;
                ViewData["ErrorMessage"] = "Invalid username or password.";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            //remove cookie
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}
