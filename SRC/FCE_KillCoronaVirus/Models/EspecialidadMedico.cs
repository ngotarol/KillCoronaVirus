using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class EspecialidadMedico
    {
        [Display(Name = "Medico")]
        public string IdUsuario { get; set; }
        [Display(Name = "Especialidad")]
        public int CodEsp { get; set; }
        [Display(Name = "Especialidad")]

        public virtual Especialidad CodEspNavigation { get; set; } = null!;
        [Display(Name = "Medico")]

        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
