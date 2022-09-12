using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Entities
{
    public class Permiso
    {

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public String Nombre { get; set; }
        public String Regla { get; set; }
        public String Global { get; set; }
        public List<Rol_Permiso> Rol_Permisos { get; set; }
    }
}
