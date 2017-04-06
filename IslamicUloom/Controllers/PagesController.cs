using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IslamicUloom.Models;

namespace IslamicUloom.Controllers
{
    public class PagesController : Controller
    {
        private DigitalLibraryEntities db = new DigitalLibraryEntities();

        // GET: Pages
        public ActionResult Index()
        {
            var pages = db.Pages.Include(p => p.Abwaab).Include(p => p.Book);
            return View(pages.ToList());
        }

        // GET: Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Pages/Create
        public ActionResult Create()
        {
            ViewBag.BaabId = new SelectList(db.Abwaabs, "BaabId", "BaabName");
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName");
            return View();
        }

        // POST: Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,BaabId,PageNumberOrder,PageDetails,PageNumberDisplay,PageTag,BookId")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaabId = new SelectList(db.Abwaabs, "BaabId", "BaabName", page.BaabId);
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", page.BookId);
            return View(page);
        }

        // GET: Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaabId = new SelectList(db.Abwaabs, "BaabId", "BaabName", page.BaabId);
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", page.BookId);
            return View(page);
        }

        // POST: Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,BaabId,PageNumberOrder,PageDetails,PageNumberDisplay,PageTag,BookId")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaabId = new SelectList(db.Abwaabs, "BaabId", "BaabName", page.BaabId);
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", page.BookId);
            return View(page);
        }

        // GET: Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Pages/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            db.Pages.Remove(page);
            db.SaveChanges();
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
