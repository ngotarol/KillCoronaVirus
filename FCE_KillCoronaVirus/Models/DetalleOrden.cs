using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class DetalleOrden
    {
        public int IdDetOrden { get; set; }
        public int NroOrden { get; set; }
        public int CodExa { get; set; }

        public virtual Examan CodExaNavigation { get; set; } = null!;
        public virtual Orden NroOrdenNavigation { get; set; } = null!;
    }
}
