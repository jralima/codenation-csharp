using AceleraDev.Domain.Models;
using AceleraDev.Domain.Repositories.Base;
using System.Collections.Generic;

namespace AceleraDev.Domain.Repositories
{
    /// <summary>
    /// Classe Cliente Repository
    /// </summary>
    public class ClienteRepository: RepositoryBase<Cliente>, IClienteRepository
    // IClienteRepository => não seria necessário pois a implementação já estaria no RepositoryBase
    // IClienteRepository => foi incluido pois definimos na interface um método que seria especifico desta classe
    {
        public ClienteRepository()
        {
            base._mock = new List<Cliente>
            {
                new Cliente
                {
                    Nome = "Lacerda",
                    Sobrenome = "Lima",
                    Cpf = "084.045.687-58"
                }
            };
        }

        public List<Cliente> BuscarTop10()
        {
            throw new System.NotImplementedException();
        }
    }
}
