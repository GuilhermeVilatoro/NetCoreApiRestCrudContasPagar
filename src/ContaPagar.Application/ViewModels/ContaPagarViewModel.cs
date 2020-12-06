﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContaPagar.Application.ViewModels
{
    public class ContaPagarViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor Original")]
        [DisplayName("valor Original")]
        public decimal ValorOriginal { get; set; }

        [Required(ErrorMessage = "Preencha a Data de Pagamento")]
        [DisplayName("Data Pagamento")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Preencha a Data de Vencimento")]
        [DisplayName("Data Vencimento")]
        public DateTime DataVencimento { get; set; }
    }
}