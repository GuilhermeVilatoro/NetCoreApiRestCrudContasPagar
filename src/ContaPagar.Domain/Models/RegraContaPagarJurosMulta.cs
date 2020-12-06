using ContaPagar.Domain.Enums;

namespace ContaPagar.Domain.Models
{
    public class RegraContaPagarJurosMulta
    {
        public long Id { get; set; }

        public TipoRegraEnum TipoRegra { get; set; }

        public decimal Multa { get; set; }

        public decimal JurosAoDia { get; set; }
    }
}