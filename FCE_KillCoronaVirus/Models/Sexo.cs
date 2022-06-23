using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Pacientes = new HashSet<Paciente>();
            Usuarios = new HashSet<Usuario>();
        }

        public int CodSexo { get; set; }
        public string NomSexo { get; set; } = null!;

        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
