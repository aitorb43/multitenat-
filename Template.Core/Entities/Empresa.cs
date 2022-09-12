using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public List<Usuario_Empresa> Usuario_Empresas { get; set; }
        public List<Permiso> Permisos { get; set; }

    }
}
