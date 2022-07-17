using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class EspecialidadMedico
    {
        public string IdUsuario { get; set; }
        public int CodEsp { get; set; }

        public virtual Especialidad CodEspNavigation { get; set; } = null!;
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
