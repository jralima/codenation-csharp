using AceleraDev.Application.ViewModels.Base;

namespace AceleraDev.Application.ViewModels
{
    public class ProdutoViewModel : ViewModelBase
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}