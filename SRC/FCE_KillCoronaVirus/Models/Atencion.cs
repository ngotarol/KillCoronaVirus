using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Atencion
    {
        public Atencion()
        {
            Ordens = new HashSet<Orden>();
            Receta = new HashSet<Recetum>();
        }


        public int NroAtencion { get; set; }
        [Display(Name = "Detalle de la atencion")]
        [Required(ErrorMessage = "Para registrar una atencion debe registra el {0}")]
        public string DatAtencion { get; set; } = null!;

        [Display(Name = "Fecha de atencion")]
        [Required(ErrorMessage = "Para registrar una atencion debe registra la {0}")]
        public int IdPac { get; set; }
        public string IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Paciente IdPacNavigation { get; set; } = null!;
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
