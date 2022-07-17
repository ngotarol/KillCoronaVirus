using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Atencions = new HashSet<Atencion>();
            Ordens = new HashSet<Orden>();
            Receta = new HashSet<Recetum>();
        }

        public int IdUsuario { get; set; }
        public int RutUsuario { get; set; }
        public string NomUsuario { get; set; } = null!;
        public int CodRol { get; set; }
        public int CodSexo { get; set; }

        public virtual Rol CodRolNavigation { get; set; } = null!;
        public virtual Sexo CodSexoNavigation { get; set; } = null!;
        public virtual ICollection<Atencion> Atencions { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
