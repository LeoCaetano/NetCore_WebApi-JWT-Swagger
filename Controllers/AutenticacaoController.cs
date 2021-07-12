using Microsoft.AspNetCore.Mvc;
using NetCore_WebApi_JWT_Swagger.Entidades;
using NetCore_WebApi_JWT_Swagger.Repositorios;

namespace NetCore_WebApi_JWT_Swagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly UsuarioRepositorio _repositorio;

        public AutenticacaoController()
        {
            _repositorio = new UsuarioRepositorio();
        }

        [HttpPost]
        public ActionResult<string> Login([FromBody] Usuario usuario)
        {
            Usuario usu = _repositorio.Login(usuario);

            if (usu == null)
                return NotFound();

            return "";
        }
    }
}
