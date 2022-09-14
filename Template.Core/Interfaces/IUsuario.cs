using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Entities;

namespace Template.Core.Interfaces
{
    internal interface IUsuario
    {
        public int Id { get; set; }
        public String Foto { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        //public String ConfirmarPassword { get; set; }
        public String TipoUsuario { get; set; }
        public Boolean EsActivo { get; set; }
        public String DNI { get; set; }
        public String Celular { get; set; }
        public String Idioma { get; set; }
        public String TipoNotificacion { get; set; }
        public String ZonaHoraria { get; set; }
        //public List<Usuario_Empresa> Usuario_Empresas { get; set; }

    }
}
