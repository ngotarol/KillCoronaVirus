using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Atencion
    {
        public Atencion()
        {
            Ordens = new HashSet<Orden>();
            Receta = new HashSet<Recetum>();
        }

        public int NroAtencion { get; set; }
        public string DatAtencion { get; set; } = null!;
        public int IdPac { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Paciente IdPacNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
