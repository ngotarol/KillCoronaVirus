using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Farmaco
    {
        public Farmaco()
        {
            DetalleReceta = new HashSet<DetalleRecetum>();
        }
        
        [Display(Name = "Codigo")]
        public int CodFar { get; set; }
        [Display(Name = "Descripcion farmaco")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string NomFar { get; set; } = null!;
        [Display(Name = "Concentracion")]
        [Required(ErrorMessage = "Debe indicar una {0}")]
        public double Concentracion { get; set; }
        [Display(Name = "Unidad de medida")]
        [Required(ErrorMessage = "Debe indicar una {0}")]
        public int CodUom { get; set; }
        [Display(Name = "Presentacion")]
        [Required(ErrorMessage = "Debe indicar una {0}")]
        public int CodPresentacion { get; set; }

        [Display(Name = "Presentacion")]
        public virtual PresentacionFarmaco CodPresentacionNavigation { get; set; } = null!;
        [Display(Name = "Unidad de medida")]
        public virtual UnidadDeMedidum CodUomNavigation { get; set; } = null!;

        public virtual ICollection<DetalleRecetum> DetalleReceta { get; set; }
    }
}
