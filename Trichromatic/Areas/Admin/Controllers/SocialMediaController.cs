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
    public class SocialMediaController : Controller
    {
        private TrichromaticEntities db = new TrichromaticEntities();

        // GET: /Admin/SocialMedia/
        public async Task<ActionResult> Index()
        {
            return View(await db.SocialMedias.ToListAsync());
        }

        // GET: /Admin/SocialMedia/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialmedia = await db.SocialMedias.FindAsync(id);
            if (socialmedia == null)
            {
                return HttpNotFound();
            }
            return View(socialmedia);
        }

        // GET: /Admin/SocialMedia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/SocialMedia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,Link,Icon,SortOrder,Active")] SocialMedia socialmedia)
        {
            if (ModelState.IsValid)
            {
                db.SocialMedias.Add(socialmedia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(socialmedia);
        }

        // GET: /Admin/SocialMedia/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialmedia = await db.SocialMedias.FindAsync(id);
            if (socialmedia == null)
            {
                return HttpNotFound();
            }
            return View(socialmedia);
        }

        // POST: /Admin/SocialMedia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Name,Link,Icon,SortOrder,Active")] SocialMedia socialmedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialmedia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(socialmedia);
        }

        // GET: /Admin/SocialMedia/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialmedia = await db.SocialMedias.FindAsync(id);
            if (socialmedia == null)
            {
                return HttpNotFound();
            }
            return View(socialmedia);
        }

        // POST: /Admin/SocialMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SocialMedia socialmedia = await db.SocialMedias.FindAsync(id);
            db.SocialMedias.Remove(socialmedia);
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
