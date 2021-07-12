using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_WebApi_JWT_Swagger.Entidades;
using NetCore_WebApi_JWT_Swagger.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_WebApi_JWT_Swagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private readonly ProdutoRepositorio _repositorio;

        public ProdutosController(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Busca Todos os Produtos.
        /// </summary>
        /// <returns>Retorna Todos os Produtos</returns>
        /// <response code="200">Lista dos Produtos</response>   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            List<Produto> produtos = _repositorio.GetProdutos();

            return Ok(produtos);
        }

        /// <summary>
        /// Busca Produto por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna Produto pelo Id informado</returns>
        /// <response code="200">Retorna Produto</response>
        /// <response code="404">Produto não encontrado</response>   
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Produto> Get(int id)
        {
            Produto produto = _repositorio.GetProduto(id);

            if (produto == null)
                NotFound();

            return Ok(produto);
        }

        /// <summary>
        /// Adiciona um Novo Produto.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Id": 0,
        ///        "Nome": "Produto 1",
        ///        "Marca": "Marca 1"
        ///     }
        ///
        /// </remarks>
        /// <param name="produto"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Produto Criado</response>
        /// <response code="400">Produto Inválido</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Produto> Add([FromBody]Produto produto)
        {
            _repositorio.AddProduto(produto);

            return Created($"Get/{produto.Id}", produto);
        }

        /// <summary>
        /// Atualiza um Produto.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        "Id": 0,
        ///        "Nome": "Produto 1",
        ///        "Marca": "Marca 1"
        ///     }
        ///
        /// </remarks>
        /// <param name="produto"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Produto Atualizado</response>
        /// <response code="400">Produto Não encontrado</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Produto> Update([FromBody] Produto produto)
        {
            Produto retorno = _repositorio.UpdateProduto(produto);

            if(retorno == null)
                return BadRequest();

            return Ok(retorno);
        }

    }
}
