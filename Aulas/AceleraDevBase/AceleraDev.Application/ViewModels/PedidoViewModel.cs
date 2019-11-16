using AceleraDev.Application.ViewModels.Base;
using AceleraDev.Domain.Models;
using System;

namespace AceleraDev.Application.ViewModels
{
    public class PedidoViewModel : ViewModelBase
    {
        public long Numero { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}