using AceleraDev.Domain.Models;
using AceleraDev.Data.Repositories.Base;
using System.Collections.Generic;
using AceleraDev.Domain.Repositories;
using AceleraDev.Data.Repositories.Context;
using System.Linq;

namespace AceleraDev.Data.Repositories
{
    /// <summary>
    /// Classe Cliente Repository
    /// </summary>
    public class ClienteRepository: RepositoryBase<Cliente>, IClienteRepository
    // IClienteRepository => não seria necessário pois a implementação já estaria no RepositoryBase
    // IClienteRepository => foi incluido pois definimos na interface um método que seria especifico desta classe
    {
        public ClienteRepository(AceleraDevContext context): base(context)
        {
            //base._mock = new List<Cliente>
            //{
            //    new Cliente
            //    {
            //        Nome = "Lacerda",
            //        Sobrenome = "Lima",
            //        Cpf = "084.045.687-58"
            //    }
            //};
        }

        public List<Cliente> BuscarTop10()
        {
            return _context.Clientes.Take(10).ToList();
        }
    }
}
