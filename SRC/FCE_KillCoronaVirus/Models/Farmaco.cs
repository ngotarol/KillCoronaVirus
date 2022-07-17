using System;
using System.Collections.Generic;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Farmaco
    {
        public Farmaco()
        {
            DetalleReceta = new HashSet<DetalleRecetum>();
        }

        public int CodFar { get; set; }
        public string NomFar { get; set; } = null!;
        public double Concentracion { get; set; }
        public int CodUom { get; set; }
        public int CodPresentacion { get; set; }

        public virtual PresentacionFarmaco CodPresentacionNavigation { get; set; } = null!;
        public virtual UnidadDeMedidum CodUomNavigation { get; set; } = null!;
        public virtual ICollection<DetalleRecetum> DetalleReceta { get; set; }
    }
}
