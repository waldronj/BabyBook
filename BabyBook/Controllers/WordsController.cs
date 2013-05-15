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
    [Authorize(Roles = 'Admin, Family')]
    public class WordsController : Controller
    {
        private jwaldronBBookEntities db = new jwaldronBBookEntities();

        //
        // GET: /Words/

        public ActionResult Index()
        {
            return View(db.Words.ToList());
        }

        //
        // GET: /Words/Details/5

        public ActionResult Details(int id = 0)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // GET: /Words/Create
        [Authorize(Roles = 'Admin')]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Words/Create
        [Authorize(Roles = 'Admin')]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Words.Add(word);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(word);
        }

        //
        // GET: /Words/Edit/5
        [Authorize(Roles = 'Admin')]
        public ActionResult Edit(int id = 0)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // POST: /Words/Edit/5
        [Authorize(Roles = 'Admin')]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(word);
        }

        //
        // GET: /Words/Delete/5
        [Authorize(Roles = 'Admin')]
        public ActionResult Delete(int id = 0)
        {
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        //
        // POST: /Words/Delete/5
        [Authorize(Roles = 'Admin')]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Word word = db.Words.Find(id);
            db.Words.Remove(word);
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