using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Package
    {
        [Key]
        public int PackageID { get; set; }

        [Display(Name = "Tipo envase:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Type { get; set; }

        [Display(Name = "Material:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Material { get; set; }

        //Relations

        public virtual ICollection<Product> Products { get; set; }
    }
}