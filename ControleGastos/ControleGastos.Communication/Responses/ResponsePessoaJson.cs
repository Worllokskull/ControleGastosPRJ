using ControleGastos.Communication.Responses.transacao;

namespace ControleGastos.Communication.Responses
{
    public class ResponsePessoaJson
    {
        public Guid id {  get; set; }
        public string Nome { get; set; } = string.Empty;
        public int idade { get; set; }
        public List<ResponseShortTransacaoJson> transacoes { get; set; } = [];
        public decimal totalGasto { get; set; }
    }
}
