using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupermercadoSA.Models;

namespace SupermercadoSA.Controllers
{
    public class CharacteristicsController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Characteristics
        public ActionResult Index()
        {
            return View(db.Characteristics.ToList());
        }

        // GET: Characteristics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return HttpNotFound();
            }
            return View(characteristic);
        }

        // GET: Characteristics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characteristics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacteristicID,Name,Brand")] Characteristic characteristic)
        {
            if (ModelState.IsValid)
            {
                db.Characteristics.Add(characteristic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(characteristic);
        }

        // GET: Characteristics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return HttpNotFound();
            }
            return View(characteristic);
        }

        // POST: Characteristics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacteristicID,Name,Brand")] Characteristic characteristic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characteristic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(characteristic);
        }

        // GET: Characteristics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return HttpNotFound();
            }
            return View(characteristic);
        }

        // POST: Characteristics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Characteristic characteristic = db.Characteristics.Find(id);
            db.Characteristics.Remove(characteristic);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
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
