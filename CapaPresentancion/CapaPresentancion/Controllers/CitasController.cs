using CapaDatos.ViewModels;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentancion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly CitasNegocio citas;

        public CitasController(CitasNegocio citas)
        {
            this.citas = citas;
        }

        [HttpPost]
        public ActionResult<CitasViewModel> PostCitas(CitasViewModel CitasFronend) 
        {
            var datos = citas.CrearCitas(CitasFronend);
            if (datos == null)
            {
                return NotFound("Alguno de los Datos esta mal");
            }
            
            return Ok(datos);
        }

        [HttpGet]
        public ActionResult<List<CitasViewModel>> PostCitas(string NombreUsuario)
        {
            var datos = citas.MostrarCitas(NombreUsuario).ToList();
            if (datos == null)
            {
                return NotFound();
            }

            return datos.ToList();
        }

        [HttpPut]
        public ActionResult<CitasViewModel> PutCitas(CitasViewModel NewDatos)
        {
            var datos = citas.ActualizarCitas(NewDatos);
            if (datos == null)
            {
                return NotFound("Los datos no se pudieron Actualizar");
            }
            return Ok(datos);
        }

        [HttpDelete]
        public ActionResult EliminarCita(string nombre)
        {
            var datos = citas.EliminarCitas(nombre);
            if (datos == null)
            {
                return NotFound("Hubo un error al eliminar lo datos");
            }
            return Ok();
        }
    }
    
}
