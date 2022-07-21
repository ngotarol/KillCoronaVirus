using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class TipoExaman
    {
        public TipoExaman()
        {
            Examen = new HashSet<Examan>();
        }
        [Display(Name = "Codigo")]
        public int CodTipo { get; set; }
        [Display(Name = "Tipo examen")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string NomTipo { get; set; } = null!;

        public virtual ICollection<Examan> Examen { get; set; }
    }
}
