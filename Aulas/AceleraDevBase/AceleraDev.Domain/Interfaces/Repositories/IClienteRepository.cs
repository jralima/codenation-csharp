using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models;
using System.Collections.Generic;

namespace AceleraDev.Domain.Repositories
{
    /// <summary>
    /// Interface Cliente Repository
    /// </summary>
    public interface IClienteRepository: IRepositoryBase<Cliente>
    {
        List<Cliente> BuscarTop10();
    }
}
