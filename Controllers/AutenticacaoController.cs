using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_WebApi_JWT_Swagger.Entidades;
using NetCore_WebApi_JWT_Swagger.Repositorios;
using NetCore_WebApi_JWT_Swagger.Servicos;

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

        /// <summary>
        /// Realiza Login.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Id": 0,
        ///        "Login": "login",
        ///        "Senha": "senha123"
        ///     }
        ///
        /// </remarks>
        /// <param name="usuario"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Login Efetuado</response>
        /// <response code="404">Usuário ou senha inválidos</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public ActionResult<string> Login([FromBody] Usuario usuario)
        {
            Usuario usu = _repositorio.Login(usuario);

            if (usu == null)
                return Unauthorized();

            string token = ServicoToken.GerarToken(usu);
            return token;
        }
    }
}
