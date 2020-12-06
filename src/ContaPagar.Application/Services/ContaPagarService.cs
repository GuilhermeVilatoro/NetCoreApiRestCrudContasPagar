using AutoMapper;
using ContaPagar.Application.Services.Interfaces;
using ContaPagar.Application.ViewModels;
using ContaPagar.Domain.Repository.Interfaces;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;

namespace ContaPagar.Application.Services
{
    public class ContaPagarService : ServiceBase<ContaPagarViewModel, ContaPagarModel>, IContaPagarService
    {
        public ContaPagarService(IMapper mapper, IContaPagarRepository repository) : base(mapper, repository)
        {
        }
    }
}