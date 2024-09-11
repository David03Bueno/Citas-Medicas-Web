using CapaDatos;
using CapaDatos.ViewModels;
using CapaNegocio;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentancion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly RegistroUsuarioNegocio registro;
        private readonly LoginNegocio loginNegocio;
        public RegistroController(RegistroUsuarioNegocio registro, LoginNegocio loginNegocio)
        {
            this.loginNegocio = loginNegocio;
            this.registro = registro;
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> PostRegistro([FromBody] UsuarioViewModel usuario)
        {
            var resultado =  registro.RegistroModelo(usuario);
            if(resultado == null)
            {
                return NotFound("Ya existe un Usuario con estos Datos");
            }
            return Ok(resultado);

        }

        [HttpGet]
        public  ActionResult<ViewLoginSalida> Login(string Correo, string Contrasena)
        {
            var datos =  loginNegocio.LogginNeogcio(Correo, Contrasena);
            if (datos == null)
            {
                return NotFound("No se encuentra este Usuario");
            }
            return Ok(datos);
        } 
    }
}
