using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class PresentacionFarmaco
    {
        public PresentacionFarmaco()
        {
            Farmacos = new HashSet<Farmaco>();
        }
        [Display(Name = "Codigo")]
        public int CodPresentacion { get; set; }
        [Display(Name = "Presentacion")]
        [Required(ErrorMessage = "Debe indicar una {0}")]
        public string NomPresentacion { get; set; } = null!;

        public virtual ICollection<Farmaco> Farmacos { get; set; }
    }
}
