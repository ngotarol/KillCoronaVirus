using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class PresentacionFarmaco
    {
        public PresentacionFarmaco()
        {
            Farmacos = new HashSet<Farmaco>();
        }

        public int CodPresentacion { get; set; }
        public string NomPresentacion { get; set; } = null!;

        public virtual ICollection<Farmaco> Farmacos { get; set; }
    }
}
