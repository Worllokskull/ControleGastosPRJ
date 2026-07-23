namespace ControleGastos.API.Entities
{
    public abstract class Entitybase
    {
        public Guid id { get; set; } = Guid.NewGuid();

    }
}
