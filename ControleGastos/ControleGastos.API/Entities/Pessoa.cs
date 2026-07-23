namespace ControleGastos.API.Entities
{
    public class Pessoa : Entitybase
    {
        public string nome { get; set; } = string.Empty;
        public int idade { get; set; }
        public List<Transacao> transacoes { get; set; } = [];
        public decimal TotalGasto { get; set; } = 0;

    }
}
