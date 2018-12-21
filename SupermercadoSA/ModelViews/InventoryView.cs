using SupermercadoSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupermercadoSA.ModelViews
{
    public class InventoryView
    {
        public Batch Batch { get; set; }

        public Bromatologist Bromatologist { get; set; }

        public File File { get; set; }

        public List<Verification> Verifications { get; set; }
    }
}