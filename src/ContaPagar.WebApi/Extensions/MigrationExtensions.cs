using ContaPagar.Domain.Enums;
using ContaPagar.Domain.Models;
using ContaPagar.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContaPagar.WebApi.Extensions
{
    public static class MigrationExtensions
    {
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ContaPagarContext>())
                {
                    context.Database.Migrate();

                    if (context.RegrasContaPagarJurosMulta == null || !context.RegrasContaPagarJurosMulta.Any())
                    {
                        context.UpdateRange(new List<object>
                        {
                            new RegraContaPagarJurosMulta
                            {
                                TipoRegra = TipoRegraEnum.AteTresDias,
                                Multa = 2.0M,
                                JurosAoDia = 0.1M                                
                            },
                            new RegraContaPagarJurosMulta
                            {
                                TipoRegra = TipoRegraEnum.SuperiorTresAteCincoDias,
                                Multa = 3.0M,
                                JurosAoDia = 0.2M
                            },
                            new RegraContaPagarJurosMulta
                            {
                                TipoRegra = TipoRegraEnum.SuperiorCincoDias,
                                Multa = 5.0M,
                                JurosAoDia = 0.3M
                            }
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}