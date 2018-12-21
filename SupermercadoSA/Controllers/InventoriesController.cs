using SupermercadoSA.Models;
using SupermercadoSA.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupermercadoSA.Controllers
{
    public class InventoriesController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Inventories
        public ActionResult Index()
        {
            //var inventoryView = new InventoryView();

            //inventoryView.Bromatologist = new Bromatologist();
            //inventoryView.Batch = new Batch();
            //inventoryView.File = new File();
            //inventoryView.Verifications = new List<Verification>();

            return View();
        }

        public ActionResult NewInventory()
        {
            var inventoryView = new InventoryView();

            inventoryView.Bromatologist = new Bromatologist();
            inventoryView.Batch = new Batch();
            inventoryView.File = new File();
            inventoryView.Verifications = new List<Verification>();
            inventoryView.controls = new List<Control>();

            // Load bromatologist
            var list = db.Bromatologists.ToList();
            list.Add(new Bromatologist { BromatologistID = 0, Name = "[Seleccione un Bromatologo...]" });
            list = list.OrderBy(n => n.Name).ToList();
            ViewBag.BromatologistID = new SelectList(list, "BromatologistID", "Name");

            // load batch
            var listB = db.Batches.ToList();
            listB = listB.OrderBy(n => n.Title).ToList();
            ViewBag.BatchID = new SelectList(listB, "BatchID", "Title");

            return View(inventoryView);
        }

        [HttpPost]
        public ActionResult NewInventory(InventoryView inventoryView)
        {
            // Load bromatologist
            var list = db.Bromatologists.ToList();
            list.Add(new Bromatologist { BromatologistID = 0, Name = "[Seleccione un Bromatologo...]" });
            list = list.OrderBy(n => n.Name).ToList();
            ViewBag.BromatologistID = new SelectList(list, "BromatologistID", "Name");

            // load batch
            var listB = db.Batches.ToList();
            listB = listB.OrderBy(n => n.Title).ToList();
            ViewBag.BatchID = new SelectList(listB, "BatchID", "Title");

            inventoryView.Batch = db.Batches.Find(ViewBag.BatchID);
            return View(inventoryView);
        }

        public ActionResult ControlBatch(int MRID)
        {
            List<int> verificationIDs = db.Satisfies.Where(s => s.MRID.Equals(MRID)).Select(v => v.VerificationID).ToList();
            List<Verification> Verifications = new List<Verification>();

            //foreach (var item in verificationIDs)
            //{
            //    Verifications = db.Verifications.Where(v => v.VerificationID.Equals(item.));
            //}
            return View();
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