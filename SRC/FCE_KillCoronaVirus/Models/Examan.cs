using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Examan
    {
        public Examan()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }
        [Display(Name = "Codigo")]
        public int CodExa { get; set; }
        [Display(Name = "Descripcion Examen")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string NomExa { get; set; } = null!;
        [Display(Name = "Tipo de Examen")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public int CodTipo { get; set; }
        [Display(Name = "Tipo de Examen")]
        public virtual TipoExaman CodTipoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
