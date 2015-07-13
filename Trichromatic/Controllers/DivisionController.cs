using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trichromatic.Models;

namespace Trichromatic.Controllers
{
    public class DivisionController : Controller
    {
        //
        // GET: /Division/
        TrichromaticEntities db = new TrichromaticEntities();

        public ActionResult Index(string name)
        {
            Division division = db.Divisions.Where(x => x.Name == name).FirstOrDefault();
            return View(division);
        }
	}
}