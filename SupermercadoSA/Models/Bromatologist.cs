using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Bromatologist
    {
        [Key]
        public int BromatologistID { get; set; }

        [Display(Name = "Nombre completo:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Matricula:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string MP { get; set; }

        [Display(Name = "CUIT:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string CUIT { get; set; }

        [Display(Name = "Telefono:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Phone { get; set; }

        //Relations 

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}