using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Satisfy
    {
        [Key]
        public int SatisfyID { get; set; }

        [Display(Name = "MR:")]
        public int MRID { get; set; }

        [Display(Name = "Verificacion:")]
        public int VerificationID { get; set; }

        // Relations

        public virtual MR MR { get; set; }

        public virtual Verification Verification { get; set; }
    }
}