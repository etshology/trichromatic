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
    public class ProductController : Controller
    {
        private TrichromaticEntities db = new TrichromaticEntities();
        
        // GET: /Admin/Product/
        public async Task<ActionResult> Index()
        {
            ViewBag.db = db;

            ViewBag.Divisions = db.Divisions.ToList();
            ViewBag.Sections = db.Sections.ToList();
            ViewBag.SubSections = db.SubSections.ToList();
            ViewBag.ProductGroups = db.ProductGroups.ToList();
            
            var products = db.Products.Include(p => p.ProductGroup);
            return View(await products.ToListAsync());
        }

        public JsonResult GetSectionsDropDownList(int did)
        {
            var sections = db.Sections.Where(x=>x.DID == did).ToList();
            var viewModel = new SelectList(sections, "ID", "Title").ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubSectionsDropDownList(int sid)
        {
            var subSections = db.SubSections.Where(x => x.SID == sid).ToList();
            var viewModel = new SelectList(subSections, "ID", "Title").ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductGroupsDropDownList(int ssid)
        {
            var productGroups = db.ProductGroups.Where(x => x.SSID == ssid).ToList();
            var viewModel = new SelectList(productGroups, "ID", "Title").ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProducts(int pgid)
        {
            var products = db.Products.Where(x => x.PGID == pgid).ToList();
            var viewModel = new SelectList(products, "ID", "Name").ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.PGID = new SelectList(db.ProductGroups, "ID", "Name");
            return View();
        }

        // POST: /Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,Description,Link,PGID,SortOrder,Active")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PGID = new SelectList(db.ProductGroups, "ID", "Name", product.PGID);
            return View(product);
        }

        // GET: /Admin/Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.PGID = new SelectList(db.ProductGroups, "ID", "Name", product.PGID);
            return View(product);
        }

        // POST: /Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Name,Description,Link,PGID,SortOrder,Active")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PGID = new SelectList(db.ProductGroups, "ID", "Name", product.PGID);
            return View(product);
        }

        // GET: /Admin/Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
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
