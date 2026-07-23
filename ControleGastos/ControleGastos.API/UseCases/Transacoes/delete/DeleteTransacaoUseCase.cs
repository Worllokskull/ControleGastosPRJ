using ControleGastos.API.Infraestrutura;
using ControleGastos.Exception.ExceptionsBase;

namespace ControleGastos.API.UseCases.Transacoes.delete
{
    public class DeleteTransacaoUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ControleGastosHubDbContextc();
            var entity = dbContext.transacaos.FirstOrDefault(transacion => transacion.id == id);
            if (entity is null)
                throw new NotFound("Transacao nao encontrada");
            dbContext.transacaos.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
