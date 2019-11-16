using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Repositories;
using AceleraDev.Domain.Repositories.Base;
using System.Collections.Generic;

namespace AceleraDev.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        protected readonly IClienteRepository _clienteRespository;
        public ClienteService(IClienteRepository clienteRepository) 
            : base(clienteRepository)
        {
            _clienteRespository = clienteRepository;
        }

        public List<Cliente> BuscarTop10()
        {
            return _clienteRespository.BuscarTop10();
        }
    }
}
