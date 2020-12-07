using System.ComponentModel.DataAnnotations;

namespace ContaPagar.Application.ViewModels
{
    public class UpdateContaPagarViewModel : BaseContaPagarViewModel
    {
        [Key]
        public long Id { get; set; }
    }
}