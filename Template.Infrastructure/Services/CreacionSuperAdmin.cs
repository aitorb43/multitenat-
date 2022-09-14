using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Infrastructure.Data;

namespace Template.Infrastructure.Services
{
    public class CreacionSuperAdmin
    {
        String email;
        String password;
        public CreacionSuperAdmin(String email, String password) {
             this.email = email;
            this.password = password;
            
            ExisteUsuario();
        }
        public void ExisteUsuario()
        {
            using (var db = new TemplateContext())
            {
                if (db.Usuario.Count() == 0) {
                    Usuario UsuarioAdmin = new Usuario {
                    Id = 1,
                    Foto = "imagen",
                    Nombre = "super",
                    Apellido = "Admin",
                    Email = email,
                    Password = password,
                    TipoUsuario = "",
                    EsActivo = true,
                    DNI = "xxxxxxx",
                    Celular = "0212-xxxxx",
                    Idioma = "ingles",
                    TipoNotificacion= "1",
                    ZonaHoraria = "Carcas"
                    };

                    db.Usuario.Add(UsuarioAdmin);
                    db.SaveChanges();
                
                } 
                    
            }

        }

    }
}
