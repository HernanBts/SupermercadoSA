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
    public class MRsController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: MRs
        public ActionResult Index()
        {
            return View(db.MRs.ToList());
        }

        // GET: MRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MR mR = db.MRs.Find(id);
            if (mR == null)
            {
                return HttpNotFound();
            }
            return View(mR);
        }

        // GET: MRs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MRs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MRID,Number,TempMin,TempMax")] MR mR)
        {
            if (ModelState.IsValid)
            {
                db.MRs.Add(mR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mR);
        }

        // GET: MRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MR mR = db.MRs.Find(id);
            if (mR == null)
            {
                return HttpNotFound();
            }
            return View(mR);
        }

        // POST: MRs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MRID,Number,TempMin,TempMax")] MR mR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mR);
        }

        // GET: MRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MR mR = db.MRs.Find(id);
            if (mR == null)
            {
                return HttpNotFound();
            }
            return View(mR);
        }

        // POST: MRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MR mR = db.MRs.Find(id);
            db.MRs.Remove(mR);
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
