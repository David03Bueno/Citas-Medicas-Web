using CapaDatos;
using CapaDatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DashboardCitasNegocio
    {
        private ClaseContexto db;

        public DashboardCitasNegocio(ClaseContexto db)
        {
            this.db = db;
        }

        public List<DashboardViewCitas> ObtenerTodo()
        {
            var datos = db.Citas.Select(x => new DashboardViewCitas
            {
                NombreUsuario = x.UsuarioID.NombreCompleto,
                MotivoCita = x.MotivoCita,
                NombreDoctor = x.DoctorID.NombreCompleto,
                Horario = x.HorarioID.Horario,
            }).ToList();

            return datos.ToList();

        }
            public List<DashboardViewCitas> PorDoctor(string nombre)
        {
            var existe = db.Citas.Where(x => x.DoctorID.NombreCompleto == nombre);
            if (existe == null)
            {
              return null;  
            }

            var datos = existe.Select(x => new DashboardViewCitas
            {
                NombreUsuario = x.UsuarioID.NombreCompleto,
                MotivoCita = x.MotivoCita,
                NombreDoctor = x.DoctorID.NombreCompleto,
                Horario = x.HorarioID.Horario,
            }).ToList();

            return datos.ToList();
        }

        public List<DashboardViewCitas> PorHorario(string nombre)
        {
            var existe = db.Citas.Where(x => x.HorarioID.Horario == nombre);
            if (existe == null)
            {
                return null;
            }

            var datos = existe.Select(x => new DashboardViewCitas
            {
                NombreUsuario = x.UsuarioID.NombreCompleto,
                MotivoCita = x.MotivoCita,
                NombreDoctor = x.DoctorID.NombreCompleto,
                Horario = x.HorarioID.Horario,
            }).ToList();

            return datos.ToList();
        }

        public List<DashboardViewCitas> PorUsuario(string nombre)
        {
            var existe = db.Citas.Where(x => x.UsuarioID.NombreCompleto == nombre);
            if (existe == null)
            {
                return null;
            }

            var datos = existe.Select(x => new DashboardViewCitas
            {
                NombreUsuario = x.UsuarioID.NombreCompleto,
                MotivoCita = x.MotivoCita,
                NombreDoctor = x.DoctorID.NombreCompleto,
                Horario = x.HorarioID.Horario,
            }).ToList();

            return datos.ToList();
        }
    }
}
