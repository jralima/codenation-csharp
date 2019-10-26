using System;
using System.Collections.Generic;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Models;

namespace AceleraDev.Application.Interfaces
{
    public interface IProdutoAppService
    {
        void Add(ProdutoViewModel obj);
        void Update(ProdutoViewModel obj);
        void Remove(Guid id);
        ProdutoViewModel GetById(Guid id);
        IList<ProdutoViewModel> GetAll();
        IList<ProdutoViewModel> Find(Func<Produto, bool> predicate);
    }
}