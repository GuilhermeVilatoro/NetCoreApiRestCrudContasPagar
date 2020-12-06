using AutoMapper;
using ContaPagar.Application.ViewModels;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;

namespace ContaPagar.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContaPagarViewModel, ContaPagarModel>();            
        }
    }
}