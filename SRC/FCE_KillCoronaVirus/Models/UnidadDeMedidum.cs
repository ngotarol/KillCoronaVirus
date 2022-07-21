using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class UnidadDeMedidum
    {
        public UnidadDeMedidum()
        {
            Farmacos = new HashSet<Farmaco>();
        }
        [Display(Name = "Codigo")]
        public int CodUom { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string NomUom { get; set; } = null!;
        [Display(Name = "Unidad")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string Uom { get; set; } = null!;

        public virtual ICollection<Farmaco> Farmacos { get; set; }
    }
}
