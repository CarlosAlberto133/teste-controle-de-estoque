using Microsoft.EntityFrameworkCore;
using controle_de_estoque_api.Models;

namespace controle_de_estoque_api.Data
{
    public class ControleEstoqueContext : DbContext
    {
        public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options) : base(options)
        {
        }

        public DbSet<Estoque> Estoque { get; set; }
    }
}
