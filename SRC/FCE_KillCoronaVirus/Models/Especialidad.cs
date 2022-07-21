using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCE_KillCoronaVirus.Models
{
    public partial class Especialidad
    {
        [Display(Name = "Codigo")]
        public int CodEsp { get; set; }
        [Display(Name = "Descripcion Especialidad")]
        [Required(ErrorMessage = "Debe indicar una {0}")]
        public string NomEsp { get; set; } = null!;
    }
}
