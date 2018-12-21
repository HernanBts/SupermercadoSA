using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Verification
    {
        [Key]
        public int VerificationID { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Tipo de dato:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Type { get; set; }

        // Relations

        public virtual ICollection<Satisfy> Satisfys { get; set; }

        public virtual ICollection<Control> Controls { get; set; }
    }
}