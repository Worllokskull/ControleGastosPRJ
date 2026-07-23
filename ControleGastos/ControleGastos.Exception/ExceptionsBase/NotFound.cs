using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Exception.ExceptionsBase
{
    public class NotFound : ControleGastosException
    {
        public NotFound(string errorMessage) : base(errorMessage)
        {

        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
