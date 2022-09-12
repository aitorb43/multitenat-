using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Entities
{
    
    public class Rol_Permiso
    {
        
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public Rol Rol { get; set; }
        public Permiso Permiso { get; set; }

    }
}
