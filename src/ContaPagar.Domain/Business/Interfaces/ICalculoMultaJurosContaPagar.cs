namespace ContaPagar.Domain.Business.Interfaces
{
    public interface ICalculoMultaJurosContaPagar
    {
        /// <summary>
        /// Responsável por realizar o cálculo de juros e multas de uma determinado contas a pagar vencido seguindo a parametrização de quantidade de dias.
        /// </summary>
        /// <param name="valorOriginal">Valor original do contas a pagar</param>
        /// <param name="quantidadeDiasVencido">Quantidade de dias que a conta está vencida</param>
        /// <returns>Retorna o valor do conta a pagar já com a correção de juros e multa</returns>
        decimal Calcular(decimal valorOriginal, int quantidadeDiasVencido);
    }
}