using System.ComponentModel;

namespace ContaPagar.Application.ViewModels
{
    public class DetalheContaPagarViewModel : BaseContaPagarViewModel
    {
        public long Id { get; set; }

        [DisplayName("Valor Corrigido")]
        public decimal ValorCorrigido { get; set; }

        [DisplayName("Quantidade Dias em Atraso")]
        public int QuantidadeDiasEmAtraso { get; set; }
    }
}