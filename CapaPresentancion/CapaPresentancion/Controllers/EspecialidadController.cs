using CapaDatos;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentancion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly AdminEspecialidaNegocio admin;

        public EspecialidadController(AdminEspecialidaNegocio admin)
        {
            this.admin = admin;
        }

        [HttpGet]
        public ActionResult<AdminEspecialidaNegocio> Get()
        {
            var datos = admin.MostrarEspecialidad().ToList();
            if (datos == null)
            {
                return NotFound("No hay datos");
            }
            return Ok(datos);
        }

        [HttpPost]
        public ActionResult<EspecialidadModelo> PostEspecialidad(EspecialidadModelo especialidad)
        {
            var datos = admin.CrearEspecialidad(especialidad);
            if (datos == null)
            {
                return NotFound("Esta Especialidad ya Existe");
            }
            return datos;
        }

        [HttpPut]
        public ActionResult<EspecialidadModelo> PutEspecialidades(EspecialidadModelo especialidad)
        {
            var datos = admin.ActualizarEspecialidades(especialidad);
            if (datos == null)
            {
                return NotFound("No se encuentra esta especialidad");
            }
            return Ok(datos);
        }

        [HttpDelete]
        public ActionResult<EspecialidadModelo> DeleteEspecialidad(EspecialidadModelo especialidad)
        {
            var datos = admin.EliminarEspecialidades(especialidad);
            if (datos == null)
            {
                return NotFound("No existe este Id");
            }
            return Ok(datos);
        }
    }
}
