using ContaPagar.Application.ViewModels;

namespace ContaPagar.Application.Services.Interfaces
{
    public interface IContaPagarService : IServiceBase<DetalheContaPagarViewModel>
    {
        /// <summary>
        /// Responsável por adicionar um contas a pagar.
        /// </summary>
        /// <param name="addContaPagarViewModel">Dados para inserir um contas a pagar</param>
        void AdicionarContaPagar(AddContaPagarViewModel addContaPagarViewModel);

        /// <summary>
        /// Responsável por alterar um contas a pagar.
        /// </summary>
        /// <param name="updateContaPagarViewModel">Dados para alterar um contas a pagar</param>
        void AlterarContaPagar(UpdateContaPagarViewModel updateContaPagarViewModel);
    }
}