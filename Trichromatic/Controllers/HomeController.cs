using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trichromatic.Models;

namespace Trichromatic.Controllers
{
    public class HomeController : Controller
    {
        TrichromaticEntities db = new TrichromaticEntities();

        public ActionResult Index()
        {
            ViewBag.Divisions = db.Divisions.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ToList<Division>();
            return View(db.Sliders.ToList().OrderBy(x=>x.SortOrder).ThenBy(x=>x.ID));
        }

        public ActionResult About(string name)
        {
            Page aboutPage = db.Pages.Where(x => x.Name == name).FirstOrDefault();
            return View(aboutPage);
        }

        public ActionResult Contact(string name)
        {
            Page contactPage = db.Pages.Where(x => x.Name == name).FirstOrDefault();
            return View(contactPage);
        }
    }
}