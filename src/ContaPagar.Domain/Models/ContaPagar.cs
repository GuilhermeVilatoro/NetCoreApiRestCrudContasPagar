using System;

namespace ContaPagar.Domain.Models
{
    public class ContaPagar
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public decimal ValorOriginal { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public int QuantidadeDiasEmAtraso { get; set; }

        public decimal ValorCorrigido { get; set; }
    }
}