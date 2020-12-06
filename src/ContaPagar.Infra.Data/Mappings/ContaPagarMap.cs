using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;

namespace ContaPagar.Infra.Data.Mappings
{
    internal class ContaPagarMap : IEntityTypeConfiguration<ContaPagarModel>
    {
        public void Configure(EntityTypeBuilder<ContaPagarModel> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode();

            builder.Property(a => a.ValorOriginal)
                .IsRequired();

            builder.Property(a => a.DataVencimento)
            .IsRequired();

            builder.Property(a => a.DataPagamento)
            .IsRequired();

            builder.Property(a => a.QuantidadeDiasEmAtraso)
            .IsRequired();

            builder.Property(a => a.ValorCorrigido)
            .IsRequired();
        }
    }
}