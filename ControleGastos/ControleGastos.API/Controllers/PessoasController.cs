using ControleGastos.API.UseCases.Pessoas.Delete;
using ControleGastos.API.UseCases.Pessoas.GetAll;
using ControleGastos.API.UseCases.Pessoas.GetId;
using ControleGastos.API.UseCases.Pessoas.Register;
using ControleGastos.API.UseCases.Pessoas.Update;
using ControleGastos.API.UseCases.Transacoes.delete;
using ControleGastos.Communication.Requests;
using ControleGastos.Communication.Responses;
using ControleGastos.Communication.Responses.pessoa;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        #region  Registrar pessoas
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortPessoasJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody]RequestPessoasJson request)
        {
            var usecase = new RegisterPessoasUseCases();
            var response = usecase.Execute(request);
            return Created(string.Empty, response);
        }
        #endregion

        #region Update pessoas
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseShortPessoasJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestPessoasJson request)
        {
            var usecase = new UpdatePessoaUseCases();
            usecase.Execute(id, request);
            return NoContent();
        }
        #endregion
        
        #region Buscar Pessoas
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllPessoasJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult GetAll()
        {
            var usecase = new GetAllPessoasUseCase();
            var response = usecase.Execute();
            if (response.Pessoas.Count == 0)
                return NoContent();
            return Ok(response);
        }
        #endregion

        #region  Buscar Pessoa Especifica por id
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponsePessoaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var usecase = new GetPessoaByIdUseCase();
            var response = usecase.Execute(id);
            return Ok(response);
        }
        #endregion

        #region Deletar Pessoas
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var usecase = new DeletePessoaUseCase();
            usecase.Execute(id);
            return NoContent();
        }
        #endregion
    }
}
