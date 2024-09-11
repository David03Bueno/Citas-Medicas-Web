using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario {  get; set; }
        public string NombreCompleto {  get; set; }
        public string FechaNacimiento { get; set; }
        public string Dirrecion {  get; set; }
        public string Telefono { get; set;}
        public string Correo { get; set;}
        public string Contrasena {  get; set; }
        public int IdRol {  get; set; }

        [ForeignKey("IdRol")]
        public virtual RolesModelo RolID { get; set; }



    }
}
