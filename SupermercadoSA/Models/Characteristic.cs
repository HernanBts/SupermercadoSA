using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Characteristic
    {
        [Key]
        public int CharacteristicID { get; set; }

        [Display(Name = "Nombre de fantasia:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Marca:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Brand { get; set; }
        
        //Relations

        public virtual ICollection<Product> Products { get; set; }
    }
}