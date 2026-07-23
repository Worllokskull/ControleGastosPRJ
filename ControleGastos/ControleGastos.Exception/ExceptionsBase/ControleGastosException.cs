using System.Net;

namespace ControleGastos.Exception.ExceptionsBase
{
    public abstract class ControleGastosException : SystemException
    {
        public ControleGastosException(string messageerror) : base(messageerror)
        {
            
        }
        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
