using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trichromatic.Models;

namespace Trichromatic.Areas.Admin.Controllers
{
    public class DivisionsController : Controller
    {
        private TrichromaticEntities db = new TrichromaticEntities();

        // GET: /Admin/Division/
        public async Task<ActionResult> Index()
        {
            return View(await db.Divisions.ToListAsync());
        }

        // GET: /Admin/Division/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = await db.Divisions.FindAsync(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // GET: /Admin/Division/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Title,Description,Image,Banner,Name,Logo,SortOrder,Active")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Add(division);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(division);
        }

        // GET: /Admin/Division/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = await db.Divisions.FindAsync(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Admin/Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Title,Description,Image,Banner,Name,Logo,SortOrder,Active")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(division);
        }

        // GET: /Admin/Division/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = await db.Divisions.FindAsync(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Admin/Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Division division = await db.Divisions.FindAsync(id);
            db.Divisions.Remove(division);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
