using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class UnidadDeMedidum
    {
        public UnidadDeMedidum()
        {
            Farmacos = new HashSet<Farmaco>();
        }

        public int CodUom { get; set; }
        public string NomUom { get; set; } = null!;
        public string Uom { get; set; } = null!;

        public virtual ICollection<Farmaco> Farmacos { get; set; }
    }
}
