using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CharacteristicID { get; set; }

        [Display(Name = "RNPA:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string RNPA { get; set; }

        [Display(Name = "Peso:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Weight { get; set; }

        [Display(Name = "Volumen:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Volume { get; set; }

        [Display(Name = "Descipcion extra:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.MultilineText)]
        public string ExtraDescription { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int PackageID { get; set; }

        // Relations

        public virtual Characteristic Characteristic { get; set; }

        public virtual Package Package { get; set; }

        public virtual Company Company { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
    }
}