using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Display(Name = "Nombre Empresa:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "CUIT:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string CUIT { get; set; }

        [Display(Name = "RNE:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string RNE { get; set; }

        [Display(Name = "Direccion:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }

        //Relations 

        public virtual ICollection<Product> Products { get; set; }
    }
}