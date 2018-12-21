using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Nombre Cliente:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "CUIT:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string CUIT { get; set; }

        [Display(Name = "Direccion:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }

        //Relations 

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}