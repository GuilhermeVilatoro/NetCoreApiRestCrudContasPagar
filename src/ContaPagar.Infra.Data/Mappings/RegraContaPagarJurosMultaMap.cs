using ContaPagar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaPagar.Infra.Data.Mappings
{
    internal class RegraContaPagarJurosMultaMap : IEntityTypeConfiguration<RegraContaPagarJurosMulta>
    {
        public void Configure(EntityTypeBuilder<RegraContaPagarJurosMulta> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.TipoRegra)
                .IsRequired();

            builder.Property(a => a.Multa)
                .IsRequired();

            builder.Property(a => a.JurosAoDia)
                .IsRequired();
        }
    }
}