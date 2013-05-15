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
    public class MeasurementsController : Controller
    {
        private jwaldronBBookEntities db = new jwaldronBBookEntities();

        //
        // GET: /Measurements/

        public ActionResult Index()
        {
            return View(db.Measurements.ToList());
        }

        //
        // GET: /Measurements/Details/5

        public ActionResult Details(int id = 0)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        //
        // GET: /Measurements/Create
        [Authorize(Roles = 'Admin')]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Measurements/Create
        [Authorize(Roles = 'Admin')]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Measurements.Add(measurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measurement);
        }

        //
        // GET: /Measurements/Edit/5
        [Authorize(Roles = 'Admin')]
        public ActionResult Edit(int id = 0)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        //
        // POST: /Measurements/Edit/5
        [Authorize(Roles = 'Admin')]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measurement);
        }

        //
        // GET: /Measurements/Delete/5
        [Authorize(Roles = 'Admin')]
        public ActionResult Delete(int id = 0)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        //
        // POST: /Measurements/Delete/5
        [Authorize(Roles = 'Admin')]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measurement measurement = db.Measurements.Find(id);
            db.Measurements.Remove(measurement);
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