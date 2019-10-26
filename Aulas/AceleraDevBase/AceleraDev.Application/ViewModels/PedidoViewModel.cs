using AceleraDev.Application.ViewModels.Base;
using AceleraDev.Domain.Models;

namespace AceleraDev.Application.ViewModels
{
    public class PedidoViewModel : ViewModelBase
    {
        public long Numero { get; set; }
        public Cliente Cliente { get; set; }
    }
}