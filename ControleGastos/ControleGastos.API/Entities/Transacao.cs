namespace ControleGastos.API.Entities
{
    public class Transacao : Entitybase
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal valor { get; set; }

        public bool despesa { get; set; }
        public Guid PessoaID { get; set; }
    }
}
