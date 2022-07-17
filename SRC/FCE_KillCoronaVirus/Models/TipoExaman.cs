using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class TipoExaman
    {
        public TipoExaman()
        {
            Examen = new HashSet<Examan>();
        }

        public int CodTipo { get; set; }
        public string NomTipo { get; set; } = null!;

        public virtual ICollection<Examan> Examen { get; set; }
    }
}
