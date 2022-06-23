using System;
using System.Collections.Generic;


namespace FCE_KillCoronaVirus.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Atencions = new HashSet<Atencion>();
            Ordens = new HashSet<Orden>();
            Receta = new HashSet<Recetum>();
        }

        public int IdPac { get; set; }
        public int RutPac { get; set; }
        public string NomPac { get; set; } = null!;
        public DateTime FecNacPac { get; set; }
        public int EdadPac { get; set; }
        public int CodSexo { get; set; }
        public virtual Sexo CodSexoNavigation { get; set; } = null!;
        public virtual ICollection<Atencion> Atencions { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
