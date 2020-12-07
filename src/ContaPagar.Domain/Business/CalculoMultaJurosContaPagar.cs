using ContaPagar.Domain.Business.Interfaces;
using ContaPagar.Domain.Enums;
using ContaPagar.Domain.Repository.Interfaces;
using System.Linq;

namespace ContaPagar.Domain.Business
{
    public sealed class CalculoMultaJurosContaPagar : ICalculoMultaJurosContaPagar
    {
        private readonly IRegraContaPagarJurosMultaRepository _regraContaPagarJurosMultaRepository;

        public CalculoMultaJurosContaPagar(IRegraContaPagarJurosMultaRepository regraContaPagarJurosMultaRepository)
        {
            _regraContaPagarJurosMultaRepository = regraContaPagarJurosMultaRepository;
        }

        public decimal Calcular(decimal valorOriginal, int quantidadeDiasVencido)
        {
            if (quantidadeDiasVencido <= 0)
                return valorOriginal;

            var tipoRegra = TipoRegraEnum.AteTresDias;
            if (quantidadeDiasVencido > 3 && quantidadeDiasVencido <= 5)
                tipoRegra = TipoRegraEnum.SuperiorTresAteCincoDias;

            if (quantidadeDiasVencido > 5)
                tipoRegra = TipoRegraEnum.SuperiorCincoDias;

            var regra = _regraContaPagarJurosMultaRepository.GetAll().FirstOrDefault(x => x.TipoRegra == tipoRegra);

            if (regra == null)
                throw new System.Exception("Deve ser parametrizado as regras de cálculo de juros e multa previamente!");                

            var valorMulta = (valorOriginal * (regra.Multa / 100));
            var valorJuros = valorOriginal * ((regra.JurosAoDia * quantidadeDiasVencido) / 100);

            return valorOriginal + valorMulta + valorJuros;
        }
    }
}