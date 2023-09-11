using API_ClaseWeb.Entities;
using API_ClaseWeb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ClaseWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosModel _usuariosModel;
        public UsuariosController(IUsuariosModel usuariosModel)
        {
            _usuariosModel = usuariosModel;
        }

        [HttpPost]
        public IActionResult ValidarCredenciales(UsuariosEntities entidad)
        {
            var resultado = _usuariosModel.ValidarCredenciales(entidad);

            try
            {
                if (resultado != null)
                    return Ok(resultado); //codigo 200 Exitoso y devuelvo el resultado
                else
                    return NotFound();//codigo 404 no lo encontro
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//codigo 400 algo salio mal
            }
        }
    }
}
