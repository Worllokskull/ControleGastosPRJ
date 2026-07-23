using System.Net;

namespace ControleGastos.Exception.ExceptionsBase
{
    public class ErrorOnValidatorException : ControleGastosException
    {
        private readonly List<string> _errors;
        public ErrorOnValidatorException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}
