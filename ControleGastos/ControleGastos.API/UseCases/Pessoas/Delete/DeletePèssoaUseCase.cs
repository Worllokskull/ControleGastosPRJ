using ControleGastos.API.Infraestrutura;
using ControleGastos.Exception.ExceptionsBase;

namespace ControleGastos.API.UseCases.Pessoas.Delete
{
    public class DeletePessoaUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ControleGastosHubDbContextc();
            var entity = dbContext.Pessoa.FirstOrDefault(pessoa => pessoa.id == id);
            if (entity is null)
                throw new NotFound("Transacao nao encontrada");
            dbContext.Pessoa.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
