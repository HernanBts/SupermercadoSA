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
    public class SatisfiesController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Satisfies
        public ActionResult Index()
        {
            var satisfies = db.Satisfies.Include(s => s.MR).Include(s => s.Verification);
            return View(satisfies.ToList());
        }

        // GET: Satisfies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfy satisfy = db.Satisfies.Find(id);
            if (satisfy == null)
            {
                return HttpNotFound();
            }
            return View(satisfy);
        }

        // GET: Satisfies/Create
        public ActionResult Create()
        {
            ViewBag.MRID = new SelectList(db.MRs, "MRID", "MRID");
            ViewBag.VerificationID = new SelectList(db.Verifications, "VerificationID", "Name");
            return View();
        }

        // POST: Satisfies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatisfyID,MRID,VerificationID")] Satisfy satisfy)
        {
            if (ModelState.IsValid)
            {
                db.Satisfies.Add(satisfy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MRID = new SelectList(db.MRs, "MRID", "MRID", satisfy.MRID);
            ViewBag.VerificationID = new SelectList(db.Verifications, "VerificationID", "Name", satisfy.VerificationID);
            return View(satisfy);
        }

        // GET: Satisfies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfy satisfy = db.Satisfies.Find(id);
            if (satisfy == null)
            {
                return HttpNotFound();
            }
            ViewBag.MRID = new SelectList(db.MRs, "MRID", "MRID", satisfy.MRID);
            ViewBag.VerificationID = new SelectList(db.Verifications, "VerificationID", "Name", satisfy.VerificationID);
            return View(satisfy);
        }

        // POST: Satisfies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatisfyID,MRID,VerificationID")] Satisfy satisfy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satisfy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MRID = new SelectList(db.MRs, "MRID", "MRID", satisfy.MRID);
            ViewBag.VerificationID = new SelectList(db.Verifications, "VerificationID", "Name", satisfy.VerificationID);
            return View(satisfy);
        }

        // GET: Satisfies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfy satisfy = db.Satisfies.Find(id);
            if (satisfy == null)
            {
                return HttpNotFound();
            }
            return View(satisfy);
        }

        // POST: Satisfies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Satisfy satisfy = db.Satisfies.Find(id);
            db.Satisfies.Remove(satisfy);
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
