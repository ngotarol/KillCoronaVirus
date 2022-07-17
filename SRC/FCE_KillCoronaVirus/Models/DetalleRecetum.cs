using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class DetalleRecetum
    {
        public int IdDetReceta { get; set; }
        public int NroReceta { get; set; }
        public int CodFar { get; set; }
        public string Dosis { get; set; } = null!;

        public virtual Farmaco CodFarNavigation { get; set; } = null!;
        public virtual Recetum NroRecetaNavigation { get; set; } = null!;
    }
}
