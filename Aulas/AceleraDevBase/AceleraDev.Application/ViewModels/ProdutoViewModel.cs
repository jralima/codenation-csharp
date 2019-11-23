using AceleraDev.Application.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace AceleraDev.Application.ViewModels
{
    public class ProdutoViewModel : ViewModelBase
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}