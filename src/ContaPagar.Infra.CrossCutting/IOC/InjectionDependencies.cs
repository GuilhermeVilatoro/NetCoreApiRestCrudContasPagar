using ContaPagar.Application.Services;
using ContaPagar.Application.Services.Interfaces;
using ContaPagar.Domain.Business;
using ContaPagar.Domain.Business.Interfaces;
using ContaPagar.Domain.Repository.Interfaces;
using ContaPagar.Infra.Data.Context;
using ContaPagar.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ContaPagar.Infra.CrossCutting.IOC
{
    public static class InjectionDependencies
    {
        /// <summary>
        /// Responsável por realizar o registro das dependências.
        /// </summary>
        /// <param name="dependencies">Lista a qual será adicionada as dependências</param>
        public static void RegisterDependencies(IServiceCollection dependencies)
        {
            #region Repository    
            dependencies.AddScoped<IContaPagarRepository, ContaPagarRepository>();
            dependencies.AddScoped<IRegraContaPagarJurosMultaRepository, RegraContaPagarJurosMultaRepository>();
            dependencies.AddScoped<ContaPagarContext>();
            #endregion

            #region Services 
            dependencies.AddScoped<IContaPagarService, ContaPagarService>();            
            #endregion region

            #region Business 
            dependencies.AddScoped<ICalculoMultaJurosContaPagar, CalculoMultaJurosContaPagar>();
            #endregion region
        }
    }
}
