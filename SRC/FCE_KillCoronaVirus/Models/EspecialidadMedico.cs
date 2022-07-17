using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class EspecialidadMedico
    {
        public int IdUsuario { get; set; }
        public int CodEsp { get; set; }

        public virtual Especilidad CodEspNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
