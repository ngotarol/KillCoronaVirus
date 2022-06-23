using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Examan
    {
        public Examan()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int CodExa { get; set; }
        public string NomExa { get; set; } = null!;
        public int CodTipo { get; set; }

        public virtual TipoExaman CodTipoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
