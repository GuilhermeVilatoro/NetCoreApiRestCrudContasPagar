using ContaPagar.Domain.Repository.Interfaces;
using ContaPagarModel = ContaPagar.Domain.Models.ContaPagar;
using NUnit.Framework;
using ContaPagar.Domain.Models;
using NSubstitute;
using ContaPagar.Domain.Business;
using ContaPagar.Domain.Enums;
using System.Collections.Generic;
using System;

namespace ContaPagar.Domain.UnitTests.Business
{
    public class CalculoMultaJurosContaPagarTest
    {
        private IRegraContaPagarJurosMultaRepository regraContaPagarJurosMultaRepositoryMock;

        private CalculoMultaJurosContaPagar calculoMultaJurosContaPagar;

        private decimal valorOriginalContaPagar;

        private int quantidadeDiasVencido;

        [SetUp]
        public void SetUp()
        {
            regraContaPagarJurosMultaRepositoryMock = Substitute.For<IRegraContaPagarJurosMultaRepository>();
            regraContaPagarJurosMultaRepositoryMock.GetAll().Returns(PreencherRegrasContasPagar());

            calculoMultaJurosContaPagar = new CalculoMultaJurosContaPagar(regraContaPagarJurosMultaRepositoryMock);

            valorOriginalContaPagar = 1000M;
            quantidadeDiasVencido = 6;
        }

        [Test]
        public void Ao_Realizar_O_Calculo_Juros_Multa_Conta_Pagar_Que_Nao_Esta_Vencida_Deve_Retornar_Valor_Corrigido_Igual_Ao_Original()
        {
            quantidadeDiasVencido = 0;
            var valorCorrigido = calculoMultaJurosContaPagar.Calcular(valorOriginalContaPagar, quantidadeDiasVencido);
            Assert.AreEqual(valorOriginalContaPagar, valorCorrigido, "O valor corrigido deve ser igual ao original!");
        }

        [Test]
        public void Deve_Lancar_Excecao_Ao_Realizar_O_Calculo_Juros_Multa_Conta_Pagar_Vencida_Que_Nao_Possua_Regras_Juros_Multas()
        {
            regraContaPagarJurosMultaRepositoryMock = Substitute.For<IRegraContaPagarJurosMultaRepository>();
            calculoMultaJurosContaPagar = new CalculoMultaJurosContaPagar(regraContaPagarJurosMultaRepositoryMock);

            Assert.Throws<Exception>(
                () => calculoMultaJurosContaPagar.Calcular(valorOriginalContaPagar, quantidadeDiasVencido),
                   "Não deve ter regras cadastradas!");
        }

        [Test]
        public void Ao_Realizar_O_Calculo_Juros_Multa_Conta_Pagar_Vencida_A_Tres_Dias_Deve_Retornar_Valor_Corrigido_Com_Acrescimo_Juros_Multa()
        {
            quantidadeDiasVencido = 3;
            var valorCorrigido = calculoMultaJurosContaPagar.Calcular(valorOriginalContaPagar, quantidadeDiasVencido);
            Assert.AreEqual(1023M, valorCorrigido, $"O valor corrigido deve ser igual a {1023.ToString("N2")}");
        }

        [Test]
        public void Ao_Realizar_O_Calculo_Juros_Multa_Conta_Pagar_Vencida_A_Cinco_Dias_Deve_Retornar_Valor_Corrigido_Com_Acrescimo_Juros_Multa()
        {
            quantidadeDiasVencido = 5;
            var valorCorrigido = calculoMultaJurosContaPagar.Calcular(valorOriginalContaPagar, quantidadeDiasVencido);
            Assert.AreEqual(1040M, valorCorrigido, $"O valor corrigido deve ser igual a {1040.ToString("N2")}");
        }

        [Test]
        public void Ao_Realizar_O_Calculo_Juros_Multa_Conta_Pagar_Vencida_A_Seis_Dias_Deve_Retornar_Valor_Corrigido_Com_Acrescimo_Juros_Multa()
        {
            quantidadeDiasVencido = 6;
            var valorCorrigido = calculoMultaJurosContaPagar.Calcular(valorOriginalContaPagar, quantidadeDiasVencido);
            Assert.AreEqual(1068M, valorCorrigido, $"O valor corrigido deve ser igual a {1068.ToString("N2")}");
        }

        /// <summary>
        /// Responsável por preencher as regras de cálculo de juros e multa do contas a pagar
        /// </summary>
        /// <returns>Retorna as regras do contas a pagar</returns>
        private List<RegraContaPagarJurosMulta> PreencherRegrasContasPagar()
        {
            return new List<RegraContaPagarJurosMulta>
            {
                new RegraContaPagarJurosMulta
                {
                    Id = 1,
                    TipoRegra = TipoRegraEnum.AteTresDias,
                    Multa = 2.0M,
                    JurosAoDia = 0.1M
                },
                new RegraContaPagarJurosMulta
                {
                    Id = 2,
                    TipoRegra = TipoRegraEnum.SuperiorTresAteCincoDias,
                    Multa = 3.0M,
                    JurosAoDia = 0.2M
                },
                new RegraContaPagarJurosMulta
                {
                    Id = 1,
                    TipoRegra = TipoRegraEnum.SuperiorCincoDias,
                    Multa = 5.0M,
                    JurosAoDia = 0.3M
                }
            };
        }
    }
}