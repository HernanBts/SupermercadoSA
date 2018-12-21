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
    public class BromatologistsController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Bromatologists
        public ActionResult Index()
        {
            return View(db.Bromatologists.ToList());
        }

        // GET: Bromatologists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bromatologist bromatologist = db.Bromatologists.Find(id);
            if (bromatologist == null)
            {
                return HttpNotFound();
            }
            return View(bromatologist);
        }

        // GET: Bromatologists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bromatologists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BromatologistID,Name,MP,CUIT,Phone")] Bromatologist bromatologist)
        {
            if (ModelState.IsValid)
            {
                db.Bromatologists.Add(bromatologist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bromatologist);
        }

        // GET: Bromatologists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bromatologist bromatologist = db.Bromatologists.Find(id);
            if (bromatologist == null)
            {
                return HttpNotFound();
            }
            return View(bromatologist);
        }

        // POST: Bromatologists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BromatologistID,Name,MP,CUIT,Phone")] Bromatologist bromatologist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bromatologist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bromatologist);
        }

        // GET: Bromatologists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bromatologist bromatologist = db.Bromatologists.Find(id);
            if (bromatologist == null)
            {
                return HttpNotFound();
            }
            return View(bromatologist);
        }

        // POST: Bromatologists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bromatologist bromatologist = db.Bromatologists.Find(id);
            db.Bromatologists.Remove(bromatologist);
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
