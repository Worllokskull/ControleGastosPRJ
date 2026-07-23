using ControleGastos.Communication.Responses;
using ControleGastos.Communication.Responses.pessoa;
using ControleGastos.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControleGastos.API.Filters
{
    public class ExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ControleGastosException controleGastosException)
            {
                context.HttpContext.Response.StatusCode = (int)controleGastosException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ReponsesErrorMessegerJson(controleGastosException.GetErrors()));
            }
            else
            {
                ThrowUnknowError(context);
            }
        }
        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ReponsesErrorMessegerJson("Erro desconhecido"));
        }
    }
}
