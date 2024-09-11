using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AdminEspecialidaNegocio
    {
        private ClaseContexto db;

        public AdminEspecialidaNegocio(ClaseContexto db)
        {
            this.db = db;
        }

        public List<EspecialidadModelo> MostrarEspecialidad()
        {
          //  var ExisteEspecialidad = db.Especialidad.Where(x => x.IdEspecialidad == id).ToList();
            var ExisteEspecialidad2 = db.Especialidad.ToList();
            if (ExisteEspecialidad2 != null)
            {
                return ExisteEspecialidad2.ToList();
            }
            return null;
        }

        public EspecialidadModelo CrearEspecialidad(EspecialidadModelo especialidad)
        {
            var existe = db.Especialidad.FirstOrDefault(x => x.IdEspecialidad == especialidad.IdEspecialidad || x.NombreEspecialidad == especialidad.NombreEspecialidad);
            if (existe != null)
            {
                return null;
            }

            var datos = new EspecialidadModelo
            {
               // IdEspecialidad = especialidad.IdEspecialidad,
                NombreEspecialidad = especialidad.NombreEspecialidad,
            };
            db.Add(datos);
            db.SaveChanges();
            return datos;
        }

        public EspecialidadModelo ActualizarEspecialidades(EspecialidadModelo especialidad)
        {
            var existe = db.Especialidad.FirstOrDefault(x => x.IdEspecialidad == especialidad.IdEspecialidad);
            if (existe != null)
            {
                existe.NombreEspecialidad = especialidad.NombreEspecialidad;
                db.SaveChanges();
                return existe;
            }
            return null;
        }

        public EspecialidadModelo EliminarEspecialidades(EspecialidadModelo especialidad)
        {
            var existe = db.Especialidad.FirstOrDefault(x => x.IdEspecialidad == especialidad.IdEspecialidad);
            if (existe != null)
            {
                db.Remove(existe);
                db.SaveChanges();
                return existe;
            }
            return null;
        }
    }
}
