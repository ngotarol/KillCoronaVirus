using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Recetum
    {
        public Recetum()
        {
            DetalleReceta = new HashSet<DetalleRecetum>();
        }

        public int NroReceta { get; set; }
        public string IdUsuario { get; set; }
        public int IdPac { get; set; }
        public int NroAtencion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Paciente IdPacNavigation { get; set; } = null!;
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        public virtual Atencion NroAtencionNavigation { get; set; } = null!;
        public virtual ICollection<DetalleRecetum> DetalleReceta { get; set; }
    }
}
