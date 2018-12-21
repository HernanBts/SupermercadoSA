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
        // GET: Inventories
        public ActionResult Index()
        {
            var inventoryView = new InventoryView();

            inventoryView.Bromatologist = new Bromatologist();
            inventoryView.Batch = new Batch();
            inventoryView.File = new File();
            inventoryView.Verifications = new List<Verification>();

            return View(inventoryView);
        }

        public ActionResult NewInventory()
        {
            var inventoryView = new InventoryView();

            inventoryView.Bromatologist = new Bromatologist();
            inventoryView.Batch = new Batch();
            inventoryView.File = new File();
            inventoryView.Verifications = new List<Verification>();

            return View(inventoryView);
        }
    }
}