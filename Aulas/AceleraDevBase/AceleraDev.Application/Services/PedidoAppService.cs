using System;
using System.Collections.Generic;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AutoMapper;

namespace AceleraDev.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoAppService(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        public void Add(PedidoViewModel pedidoViewModel)
        {
            var modelPedido = _mapper.Map<Pedido>(pedidoViewModel);
            _pedidoService.Add(modelPedido);
        }

        public void Update(PedidoViewModel pedidoViewModel)
        {
            var modelPedido = _mapper.Map<Pedido>(pedidoViewModel);
            _pedidoService.Update(modelPedido);
        }

        public void Remove(Guid id)
        {
            _pedidoService.Remove(id);
        }

        public PedidoViewModel GetById(Guid id)
        {
            var modelPedido = _pedidoService.GetById(id);
            return _mapper.Map<PedidoViewModel>(modelPedido);
        }

        public IList<PedidoViewModel> GetAll()
        {
            var modelPedidos = _pedidoService.GetAll();
            return _mapper.Map<IList<PedidoViewModel>>(modelPedidos);
        }

        public IList<PedidoViewModel> Find(Func<Pedido, bool> predicate)
        {
            var modelPedidos = _pedidoService.Find(predicate);
            return _mapper.Map<IList<PedidoViewModel>>(modelPedidos);
        }
    }
}