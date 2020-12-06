using ContaPagar.Domain.Repository.Interfaces;
using ContaPagar.Infra.Data.Context;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;

namespace ContaPagar.Infra.Data.Repository
{
    public class ContaPagarRepository : RepositoryBase<ContaPagarModel>, IContaPagarRepository
    {
        public ContaPagarRepository(ContaPagarContext contaPagarContext) : base(contaPagarContext)
        {
        }
    }
}