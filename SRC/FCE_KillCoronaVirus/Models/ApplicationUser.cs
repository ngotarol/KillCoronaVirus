using Microsoft.AspNetCore.Identity;

namespace FCE_KillCoronaVirus.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Atencions = new HashSet<Atencion>();
            Ordens = new HashSet<Orden>();
            Receta = new HashSet<Recetum>();
        }
        public string ApMaterno { get; set; }  
        public string ApPaterno { get; set; }   
        public string Nombre    { get; set; }   

        public int CodSexo { get; set; }
        public virtual Sexo CodSexoNavigation { get; set; } = null!;
        public virtual ICollection<Atencion> Atencions { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
        public virtual ICollection<Recetum> Receta { get; set; }
    }
}
