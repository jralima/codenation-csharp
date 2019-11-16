using System;
using System.Collections.Generic;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Models;

namespace AceleraDev.Application.Interfaces
{
    public interface IClienteAppService
    {
        void Add(ClienteViewModel obj);
        void Update(ClienteViewModel obj);
        void Remove(Guid id);
        ClienteViewModel GetById(Guid id);
        IList<ClienteViewModel> GetAll();
        IList<ClienteViewModel> Find(Func<Cliente, bool> predicate);
        IEnumerable<ClienteViewModel> BuscarTop10();
    }
}