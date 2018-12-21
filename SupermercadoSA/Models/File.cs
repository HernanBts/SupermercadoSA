using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class File
    {
        [Key]
        public int FileID { get; set; }

        [Display(Name = "Lote:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int BatchID { get; set; }

        [Display(Name = "Fecha control:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool State { get; set; }

        [Display(Name = "Observacion:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Remark { get; set; }

        [Display(Name = "Bromatologo:")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int BromatologistID { get; set; }

        // Relations

        public virtual Batch Batch { get; set; }

        public virtual Bromatologist Bromatologist { get; set; }

        public virtual ICollection<Control> Controls { get; set; }
    }
}