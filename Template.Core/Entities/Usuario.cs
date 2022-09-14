using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Interfaces;

namespace Template.Core.Entities
{  
        public class Usuario : IUsuario
        {          
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public String Foto { get; set; } 
        [Required]
        [StringLength(50)]
        public String Nombre { get; set; }
        [StringLength(50)]
        public String Apellido { get; set; } 
        [Required]
        [StringLength(100)]
        public String Email { get; set; }
        [Required]
        [StringLength(500)]
        public String Password { get; set; }
        [Required]
        [NotMapped]
        [StringLength(500)]
        public String ConfirmarPassword { get; set; }
        [Required]
        [StringLength(50)]
        public String TipoUsuario { get; set; }
        [Required]
        public Boolean EsActivo { get; set; }
        [Required]
        [StringLength(50)]
        public String DNI { get; set; }
        [Required]
        [StringLength(50)]
        public String Celular { get; set; }
        [Required]
        [StringLength(50)]
        public String Idioma { get; set; }
        [Required]
        [StringLength(50)]
        public String TipoNotificacion { get; set; }
        [Required]
        [StringLength(200)]
        public String ZonaHoraria { get; set; }
        public List<Usuario_Empresa> Usuario_Empresas { get; set; }

    }
    
}
