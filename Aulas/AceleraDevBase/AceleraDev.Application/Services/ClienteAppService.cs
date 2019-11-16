using System;
using System.Collections.Generic;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AutoMapper;

namespace AceleraDev.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        
        public ClienteAppService(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
        
        public void Add(ClienteViewModel clienteViewModel)
        {
            var modelCliente = _mapper.Map<Cliente>(clienteViewModel);
            _clienteService.Add(modelCliente);
        }

        public void Update(ClienteViewModel clienteViewModel)
        {
            var modelCliente = _mapper.Map<Cliente>(clienteViewModel);
            _clienteService.Update(modelCliente);
        }

        public void Remove(Guid id)
        {
            _clienteService.Remove(id);
        }

        public ClienteViewModel GetById(Guid id)
        {
            var modelCliente = _clienteService.GetById(id);
            return _mapper.Map<ClienteViewModel>(modelCliente);
        }

        public IList<ClienteViewModel> GetAll()
        {
            var modelClientes = _clienteService.GetAll();
            return _mapper.Map<IList<ClienteViewModel>>(modelClientes);
        }

        public IList<ClienteViewModel> Find(Func<Cliente, bool> predicate)
        {
            var modelClientes = _clienteService.Find(predicate);
            return _mapper.Map<IList<ClienteViewModel>>(modelClientes);
        }

        public IEnumerable<ClienteViewModel> BuscarTop10()
        {
            var modelClientes = _clienteService.BuscarTop10();
            return _mapper.Map<List<ClienteViewModel>>(modelClientes);
        }
    }
}