using ContaPagar.Domain.Models;
using ContaPagar.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;

namespace ContaPagar.Infra.Data.Context
{
    public class ContaPagarContext : DbContext
    {
        public DbSet<ContaPagarModel> ContasPagar { get; set; }

        public DbSet<RegraContaPagarJurosMulta> RegrasContaPagarJurosMulta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaPagarMap());
            modelBuilder.ApplyConfiguration(new RegraContaPagarJurosMultaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}