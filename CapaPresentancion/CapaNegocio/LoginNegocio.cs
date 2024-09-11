using CapaDatos;
using CapaDatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LoginNegocio
    {
        private ClaseContexto db;

        public LoginNegocio(ClaseContexto db)
        {
            this.db = db;
        }

        public ViewLoginSalida LogginNeogcio(string correo, string contrasena)
        {
            var existeUsuario = db.Usuarios.Where(x => x.Correo == correo && x.Contrasena == contrasena).FirstOrDefault();
            var existeDoctor = db.Doctor.Where(x => x.Correo == correo && x.Contrasena == contrasena).FirstOrDefault();
            var existeAdmin = db.Administrador.Where(x => x.Correo == correo && x.Contrasena == contrasena).FirstOrDefault();
            
            if (existeUsuario != null)
            {
                var datos = new ViewLoginSalida
                {
                    Correo = existeUsuario.Correo,
                    Contrasena = existeUsuario.Contrasena,
                    RolId = existeUsuario.IdRol
                };
                return datos;
            }

            else if(existeDoctor != null) 
            {
                var datos = new ViewLoginSalida
                {
                    Correo = existeDoctor.Correo,
                    Contrasena = existeDoctor.Contrasena,
                    RolId = existeDoctor.IdRol
                };
                return datos;
            }
            else if (existeAdmin != null)
            {
                var datos = new ViewLoginSalida
                {
                    Correo = existeAdmin.Correo,
                    Contrasena = existeAdmin.Contrasena,
                    RolId = existeAdmin.IdRol
                };
                return datos;
            }

            return null;
        }
    }
}
