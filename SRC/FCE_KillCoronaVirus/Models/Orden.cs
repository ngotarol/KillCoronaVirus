using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Orden
    {
        public Orden()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int NroOrden { get; set; }
        public int NroAtencion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPac { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Paciente IdPacNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual Atencion NroAtencionNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
