using AutoMapper;
using ContaPagar.Application.Services.Interfaces;
using ContaPagar.Application.ViewModels;
using ContaPagar.Domain.Business.Interfaces;
using ContaPagar.Domain.Repository.Interfaces;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;

namespace ContaPagar.Application.Services
{
    public class ContaPagarService : ServiceBase<DetalheContaPagarViewModel, ContaPagarModel>, IContaPagarService
    {
        private readonly ICalculoMultaJurosContaPagar _calculoMultaJurosContaPagar;

        private readonly IContaPagarRepository _contaPagarRepository;

        private readonly IMapper _mapper;

        public ContaPagarService(IMapper mapper,
            IContaPagarRepository repository,
            ICalculoMultaJurosContaPagar calculoMultaJurosContaPagar) : base(mapper, repository)
        {
            _calculoMultaJurosContaPagar = calculoMultaJurosContaPagar;
            _contaPagarRepository = repository;
            _mapper = mapper;
        }

        public void AdicionarContaPagar(AddContaPagarViewModel addContaPagarViewModel)
        {
            _contaPagarRepository.Add(CriarContaPagarComRegraJurosMulta(addContaPagarViewModel));
        }

        public void AlterarContaPagar(UpdateContaPagarViewModel updateContaPagarViewModel)
        {
            _contaPagarRepository.Update(CriarContaPagarComRegraJurosMulta(updateContaPagarViewModel));
        }        

        /// <summary>
        /// Responsável por retornar a conta a pagar já com a regra de multa e juros aplicada.
        /// </summary>
        /// <param name="entityViewModel">Model de conta a pagar</param>
        /// <returns>Retorna a entidade de contas a pagar com multa e juros aplicada</returns>
        private ContaPagarModel CriarContaPagarComRegraJurosMulta(BaseContaPagarViewModel entityViewModel)
        {
            var entity = _mapper.Map<ContaPagarModel>(entityViewModel);

            entity.QuantidadeDiasEmAtraso =
                entityViewModel.DataPagamento > entityViewModel.DataVencimento ? (int)(entityViewModel.DataPagamento - entityViewModel.DataVencimento).TotalDays : 0;

            entity.ValorCorrigido = _calculoMultaJurosContaPagar.Calcular(entity.ValorOriginal, entity.QuantidadeDiasEmAtraso);
            return entity;
        }
    }
}