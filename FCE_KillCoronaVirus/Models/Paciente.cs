using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        [Display(Name = "RUN")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public int RutPac { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un {0}", AllowEmptyStrings = false)]
        public string NomPac { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string ApPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Debe indicar un {0}")]
        public string ApMaterno { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Debe indicar una {0}")]
        public DateTime FecNacPac { get; set; }
        [Display(Name = "Edad")]
        [Required(ErrorMessage = "Debe indicar la {0}")]
        public int EdadPac { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Debe indicar el {0}")]
        public int CodSexo { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Debe indicar el {0}")]
        public virtual Sexo CodSexoNavigation { get; set; }
        public virtual ICollection<Atencion> Atencions { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
