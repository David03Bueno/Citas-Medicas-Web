using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ViewModels
{
    public class UsuarioViewModel
    {

        public string NombreCompleto { get; set; }
        public string FechaNacimiento { get; set; }
        public string Dirrecion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }
    }
}
