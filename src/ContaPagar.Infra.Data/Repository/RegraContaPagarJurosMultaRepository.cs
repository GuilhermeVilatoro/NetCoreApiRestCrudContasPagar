using ContaPagar.Domain.Models;
using ContaPagar.Domain.Repository.Interfaces;
using ContaPagar.Infra.Data.Context;

namespace ContaPagar.Infra.Data.Repository
{
    public class RegraContaPagarJurosMultaRepository : RepositoryBase<RegraContaPagarJurosMulta>, IRegraContaPagarJurosMultaRepository
    {
        public RegraContaPagarJurosMultaRepository(ContaPagarContext contaPagarContext) : base(contaPagarContext)
        {
        }
    }
}