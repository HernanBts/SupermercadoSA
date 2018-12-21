using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Display(Name = "Cliente:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CustomerID { get; set; }

        [Display(Name = "Fecha compra:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Total:")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Total { get; set; }

        // Relations

        public virtual ICollection<Batch> Batchs { get; set; }

        public virtual Customer Customer { get; set; }
    }
}