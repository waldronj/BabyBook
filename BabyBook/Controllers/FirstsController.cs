using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyBook.Models;

namespace BabyBook.Controllers
{
    [Authorize(Roles = "Admin, Family")]
    public class FirstsController : Controller
    {
        private jwaldronBBookEntities db = new jwaldronBBookEntities();

        //
        // GET: /Firsts/

        public ActionResult Index()
        {
            return View(db.Firsts.ToList());
        }

        //
        // GET: /Firsts/Details/5

        public ActionResult Details(int id = 0)
        {
            First first = db.Firsts.Find(id);
            if (first == null)
            {
                return HttpNotFound();
            }
            return View(first);
        }

        //
        // GET: /Firsts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Firsts/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(First first)
        {
            if (ModelState.IsValid)
            {
                db.Firsts.Add(first);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(first);
        }

        //
        // GET: /Firsts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id = 0)
        {
            First first = db.Firsts.Find(id);
            if (first == null)
            {
                return HttpNotFound();
            }
            return View(first);
        }

        //
        // POST: /Firsts/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(First first)
        {
            if (ModelState.IsValid)
            {
                db.Entry(first).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(first);
        }

        //
        // GET: /Firsts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            First first = db.Firsts.Find(id);
            if (first == null)
            {
                return HttpNotFound();
            }
            return View(first);
        }

        //
        // POST: /Firsts/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            First first = db.Firsts.Find(id);
            db.Firsts.Remove(first);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}