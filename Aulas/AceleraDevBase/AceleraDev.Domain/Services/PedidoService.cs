using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Repositories;
using AceleraDev.Domain.Repositories.Base;

namespace AceleraDev.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
        {
        public PedidoService(IPedidoRepository pedidoRepository)
            : base(pedidoRepository)
            {

            }

    }
}