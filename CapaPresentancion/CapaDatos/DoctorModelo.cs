using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DoctorModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDoctor {  get; set; }
        public string NombreCompleto { get; set;}
        public string Telefono {  get; set; }
        public int IdEspecialidad { get;set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int IdRol {  get; set; }
        [ForeignKey("IdRol")]
        public virtual RolesModelo RolID { get; set; }

        [ForeignKey("IdEspecialidad")]
        public virtual EspecialidadModelo Especialidad { get; set; }
    }
}
