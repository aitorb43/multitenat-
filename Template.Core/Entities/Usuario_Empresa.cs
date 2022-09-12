using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Entities
{

    public  class Usuario_Empresa
    {
        
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public int RolId { get; set; }
        public Usuario Usuario { get; set; }
        public Empresa Empresa { get; set; }
        public Rol Rol { get; set; }




    }
}
