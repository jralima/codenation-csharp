using System;
using System.Collections.Generic;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Models;

namespace AceleraDev.Application.Interfaces
{
    public interface IPedidoAppService
    {
        void Add(PedidoViewModel obj);
        void Update(PedidoViewModel obj);
        void Remove(Guid id);
        PedidoViewModel GetById(Guid id);
        IList<PedidoViewModel> GetAll();
        IList<PedidoViewModel> Find(Func<Pedido, bool> predicate);
    }
}