using CapaDatos;
using CapaDatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CitasNegocio
    {
        private ClaseContexto db;

        public CitasNegocio(ClaseContexto db)
        {
            this.db = db;
        }

        public CitasViewModel CrearCitas(CitasViewModel citasView)
        {
            var ExisteNombre = db.Usuarios.FirstOrDefault(x => x.NombreCompleto == citasView.NombreUsuario);
            //var ExisteDoctor = db.Doctor.FirstOrDefault(x => x.IdDoctor == citasView.IdDoctor);
           // var ExisteHorario = db.Horario.FirstOrDefault(x => x.IdHorario == citasView.IdHorario);

            if (ExisteNombre != null )
            {
                var datos = new CitaModelo
                {
                    MotivoCita = citasView.MotivoCita,
                    IdUsuario = ExisteNombre.IdUsuario,
                    IdDoctor = citasView.IdDoctor,
                    IdHorario = citasView.IdHorario,
                };
                db.Add(datos);
                db.SaveChanges();
                return (citasView);
            }
            return null;

        }

        public CitasViewModel ActualizarCitas(CitasViewModel citasView)
        {
            var ExisteUsuario = db.Usuarios.FirstOrDefault(x => x.NombreCompleto == citasView.NombreUsuario);
            if (ExisteUsuario != null)
            {
                var ExisteCita = db.Citas.FirstOrDefault(x => x.IdUsuario == ExisteUsuario.IdUsuario);
                if (ExisteCita != null)
                {
                    ExisteCita.MotivoCita = citasView.MotivoCita;
                    ExisteCita.IdDoctor = citasView.IdDoctor;
                    ExisteCita.IdHorario = citasView.IdHorario;
                    db.SaveChanges();
                    return citasView;
                    
                }
            }
            return null;
        }

        public List<CitasViewModel> MostrarCitas(string nombre)
        {
            var ExisteUsuario = db.Usuarios.FirstOrDefault(x => x.NombreCompleto == nombre);
           // var listar= new List<CitasViewModel>();
            if (ExisteUsuario != null)
            {
                var ExisteCita = db.Citas.Where(x => x.IdUsuario == ExisteUsuario.IdUsuario);
                if (ExisteCita != null)
                {
                    //var ExisteDoctor = db.Doctor.FirstOrDefault(x => x.IdDoctor == ExisteCita.IdDoctor);
                    //var ExisteHorario = db.Horario.FirstOrDefault(x => x.IdHorario == ExisteCita.IdHorario);
                    var Datos = ExisteCita.Select(x => new CitasViewModel
                    {
                        NombreUsuario = ExisteUsuario.NombreCompleto,
                        MotivoCita = x.MotivoCita,
                        IdDoctor = x.DoctorID.IdDoctor,
                        IdHorario = x.HorarioID.IdHorario,
                    }).ToList();


                    //listar.Add(Datos);
                    return Datos.ToList();
                }
            }
            return null;
        }

        public CitaModelo EliminarCitas(string nombre)
        {
            var ExisteUsuario = db.Usuarios.FirstOrDefault(x => x.NombreCompleto == nombre);

            if (ExisteUsuario != null)
            {
                var ExisteCita = db.Citas.FirstOrDefault(x => x.IdUsuario == ExisteUsuario.IdUsuario);
                if (ExisteCita != null)
                {
                    db.Remove(ExisteCita);
                    db.SaveChanges();
                    return ExisteCita;
                }
            }

            return null;
        }
    }
}
