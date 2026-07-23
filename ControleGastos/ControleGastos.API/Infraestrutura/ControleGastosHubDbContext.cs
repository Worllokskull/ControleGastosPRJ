using ControleGastos.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Infraestrutura;
    public class ControleGastosHubDbContextc : DbContext
    {
    public DbSet<Pessoa> Pessoa { get; set; } = default!;
    public DbSet<Transacao> transacaos { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\Usuário\\OneDrive\\Desktop\\Projetos RocketSeat\\ControleGastos\\tabela.octet-stream");
    }
    }
    

