using AceleraDev.Domain.Models;
using AceleraDev.Data.Repositories.Base;
using AceleraDev.Domain.Repositories;

namespace AceleraDev.Data.Repositories
{
    /// <summary>
    /// Classe pedido Repository
    /// </summary>
    public class PedidoRepository: RepositoryBase<Pedido>, IPedidoRepository{
        public PedidoRepository()
        {

        }
    }
}
