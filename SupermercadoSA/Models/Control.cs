using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Control
    {
        [Key]
        public int ControlID { get; set; }

        [Display(Name = "Verificacion:")]
        public int VerificationID { get; set; }

        [Display(Name = "Ficha:")]
        public int FileID { get; set; }

        [Display(Name = "Resultado:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Result { get; set; }

        // Relations

        public virtual File File { get; set; }

        public virtual Verification Verification { get; set; }
    }
}