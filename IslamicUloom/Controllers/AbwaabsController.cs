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
    public class AbwaabsController : Controller
    {
        private DigitalLibraryEntities db = new DigitalLibraryEntities();

        // GET: Abwaabs
        public ActionResult Index()
        {
            var abwaabs = db.Abwaabs.Include(a => a.Book);
            return View(abwaabs.ToList());
        }

        // GET: Abwaabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abwaab abwaab = db.Abwaabs.Find(id);
            if (abwaab == null)
            {
                return HttpNotFound();
            }
            return View(abwaab);
        }

        // GET: Abwaabs/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName");
            return View();
        }

        // POST: Abwaabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BaabId,BaabName,BaabNumber,BookId,BaabPage")] Abwaab abwaab)
        {
            if (ModelState.IsValid)
            {
                db.Abwaabs.Add(abwaab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", abwaab.BookId);
            return View(abwaab);
        }

        // GET: Abwaabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abwaab abwaab = db.Abwaabs.Find(id);
            if (abwaab == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", abwaab.BookId);
            return View(abwaab);
        }

        // POST: Abwaabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaabId,BaabName,BaabNumber,BookId,BaabPage")] Abwaab abwaab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abwaab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", abwaab.BookId);
            return View(abwaab);
        }

        // GET: Abwaabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abwaab abwaab = db.Abwaabs.Find(id);
            if (abwaab == null)
            {
                return HttpNotFound();
            }
            return View(abwaab);
        }

        // POST: Abwaabs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abwaab abwaab = db.Abwaabs.Find(id);
            db.Abwaabs.Remove(abwaab);
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
