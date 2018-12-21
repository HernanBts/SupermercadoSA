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
    public class ProductsController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Characteristic).Include(p => p.Company).Include(p => p.Package);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Type");
            ViewBag.CharacteristicID = new SelectList(db.Characteristics, "CharacteristicID", "Name");
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name");
            ViewBag.PackageID = new SelectList(db.Packages, "PackageID", "Type");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,RNPA,Weight,Volume,ExtraDescription,PackageID,CharacteristicID,CompanyID,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Type", product.CategoryID);
            ViewBag.CharacteristicID = new SelectList(db.Characteristics, "CharacteristicID", "Name", product.CharacteristicID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name", product.CompanyID);
            ViewBag.PackageID = new SelectList(db.Packages, "PackageID", "Type", product.PackageID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Type", product.CategoryID);
            ViewBag.CharacteristicID = new SelectList(db.Characteristics, "CharacteristicID", "Name", product.CharacteristicID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name", product.CompanyID);
            ViewBag.PackageID = new SelectList(db.Packages, "PackageID", "Type", product.PackageID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,RNPA,Weight,Volume,ExtraDescription,PackageID,CharacteristicID,CompanyID,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Type", product.CategoryID);
            ViewBag.CharacteristicID = new SelectList(db.Characteristics, "CharacteristicID", "Name", product.CharacteristicID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name", product.CompanyID);
            ViewBag.PackageID = new SelectList(db.Packages, "PackageID", "Type", product.PackageID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
