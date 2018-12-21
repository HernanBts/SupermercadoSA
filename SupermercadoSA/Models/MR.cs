using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class MR
    {
        [Key]
        public int MRID { get; set; }

        [Display(Name = "Numero:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Number { get; set; }

        [Display(Name = "Temperatura minima:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int TempMin { get; set; }

        [Display(Name = "Temperatura maxima:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int TempMax { get; set; }

        // Relations

        public virtual ICollection<Batch> Batchs { get; set; }

        public virtual ICollection<Satisfy> Satisfys { get; set; }
    }
}