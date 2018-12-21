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
    public class BatchesController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Batches
        public ActionResult Index()
        {
            var batches = db.Batches.Include(b => b.MR).Include(b => b.Product).Include(b => b.Purchase);
            return View(batches.ToList());
        }

        // GET: Batches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: Batches/Create
        public ActionResult Create()
        {
            var list = db.Characteristics.ToList();
            list.Add(new Characteristic { CharacteristicID = 0, Name = "[Seleccione un producto...]"});
            list = list.OrderBy(n => n.Name).ToList();

            ViewBag.MRID = new SelectList(db.MRs, "MRID", "Number");
            ViewBag.CharacteristicID = new SelectList(list, "CharacteristicID", "Name");
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Date");
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BatchID,ProductID,Date,ElaborationDate,ExpirationDate,Peice,Quantity,MRID,PurchaseID")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Batches.Add(batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MRID = new SelectList(db.MRs, "MRID", "Number", batch.MRID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "RNPA", batch.ProductID);
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Date", batch.PurchaseID);
            return View(batch);
        }

        // GET: Batches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.MRID = new SelectList(db.MRs, "MRID", "Number", batch.MRID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "RNPA", batch.ProductID);
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Date", batch.PurchaseID);
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BatchID,ProductID,Date,ElaborationDate,ExpirationDate,Peice,Quantity,MRID,PurchaseID")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MRID = new SelectList(db.MRs, "MRID", "Number", batch.MRID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "RNPA", batch.ProductID);
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Date", batch.PurchaseID);
            return View(batch);
        }

        // GET: Batches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Batch batch = db.Batches.Find(id);
            db.Batches.Remove(batch);
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
