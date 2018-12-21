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
    public class ReportsController : Controller
    {
        private SupermercadoSAContext db = new SupermercadoSAContext();

        // GET: Reports
        public ActionResult Index()
        {

            var batches = db.Batches.Include(b => b.MR).Include(b => b.Product).Include(b => b.Purchase);
            foreach (var item in batches)
            {
                var files = db.Files.Where(f => f.BatchID.Equals(item.BatchID));
            }

            foreach (var item in batches)
            {

            }
            return View(batches.ToList());
        }
    }
}