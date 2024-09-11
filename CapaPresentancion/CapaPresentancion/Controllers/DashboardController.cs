using CapaDatos;
using CapaDatos.ViewModels;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentancion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardCitasNegocio dashboard;

        public DashboardController(DashboardCitasNegocio dashboard)
        {
            this.dashboard = dashboard;
        }

        [HttpGet]
        public ActionResult<DashboardViewCitas> GetTodos()
        {
            var datos = dashboard.ObtenerTodo().ToList();
            if (datos == null)
            {
                return NotFound("No hay datos");
            }
            return Ok(datos);
        }

        [HttpGet("PorDoctor")]
        public ActionResult<DashboardViewCitas> GetCitasPorDoctor(string nombre)
        {
            var datos = dashboard.PorDoctor(nombre).ToList();
            if (datos == null)
            {
                return NotFound("No se encuentra ese Id");
            }
            return Ok(datos);
        }

        [HttpGet("PorHorario")]
        public ActionResult<DashboardViewCitas> GetCitasPorHoraio(string nombre)
        {
            var datos = dashboard.PorHorario(nombre).ToList();
            if (datos == null)
            {
                return NotFound("No se encuentra ese Id");
            }

            return Ok(datos);
        }

        [HttpGet("PorUsuario")]
        public ActionResult<DashboardViewCitas> GetCitasPorUsuario(string nombre)
        {
            var datos = dashboard.PorUsuario(nombre).ToList();
            if (datos == null)
            {
                return NotFound("No se encuentra ese Id");
            }

            return Ok(datos);
        }
    }
}
