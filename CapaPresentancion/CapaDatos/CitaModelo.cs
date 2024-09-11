using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CitaModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita {  get; set; }
        public string MotivoCita { get; set; }
        public int IdUsuario {  get; set; }
        public int IdDoctor {  get; set; }
        public int IdHorario {  get; set; }

        [ForeignKey("IdUsuario")]
        public virtual UsuarioModelo UsuarioID { get; set; }

        [ForeignKey("IdDoctor")]
        public virtual DoctorModelo DoctorID { get; set; }

        [ForeignKey("IdHorario")]
        public virtual HorarioModelo HorarioID { get; set; }
    }
}
