using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Communication.Responses.transacao
{
    public class ResponseShortTransacaoJson
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
