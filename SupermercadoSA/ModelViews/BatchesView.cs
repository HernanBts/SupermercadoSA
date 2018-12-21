using SupermercadoSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupermercadoSA.ModelViews
{
    public class BatchesView
    {
        public List<Batch> Batches { get; set; }

        public List<File> Files { get; set; }
    }
}