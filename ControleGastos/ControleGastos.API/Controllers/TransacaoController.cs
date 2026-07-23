using ControleGastos.API.UseCases.Transacoes.delete;
using ControleGastos.API.UseCases.Transacoes.Register;
using ControleGastos.Communication.Requests;
using ControleGastos.Communication.Responses.pessoa;
using ControleGastos.Communication.Responses.transacao;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        #region  Criar Transacoes
        [HttpPost]
        [Route("{clientid}")]
        [ProducesResponseType(typeof(ResponseShortTransacaoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromRoute] Guid clientid, [FromBody] RequestTransacoesJson request)
        {
            var usecase = new RegisterTransacoesUsecases();
            var response = usecase.Execute(clientid, request);
            return Created(string.Empty, response);
        }
        #endregion 
        #region deletar Transacoes
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ReponsesErrorMessegerJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var usecase = new DeleteTransacaoUseCase();
            usecase.Execute(id);
            return NoContent();
        }
        #endregion

    }
}
