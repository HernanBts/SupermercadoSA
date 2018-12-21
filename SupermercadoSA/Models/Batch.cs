using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Batch
    {
        [Key]
        public int BatchID { get; set; }

        [Display(Name = "Producto:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProductID { get; set; }

        [Display(Name = "Fecha ingreso:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha elaboración:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ElaborationDate { get; set; }

        [Display(Name = "Fecha vencimiento:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Precio:")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Peice { get; set; }

        [Display(Name = "Cantidad:")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Quantity { get; set; }

        [Display(Name = "MR:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int MRID { get; set; }

        [Display(Name = "Compra:")]
        public int? PurchaseID { get; set; }

        // Relations

        public virtual Product Product { get; set; }

        public virtual MR MR { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}