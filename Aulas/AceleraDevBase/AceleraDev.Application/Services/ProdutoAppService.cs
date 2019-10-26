using System;
using System.Collections.Generic;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AutoMapper;

namespace AceleraDev.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        
        public void Add(ProdutoViewModel produtoViewModel)
        {
            var modelProduto = _mapper.Map<Produto>(produtoViewModel);
            _produtoService.Add(modelProduto);
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            var modelProduto = _mapper.Map<Produto>(produtoViewModel);
            _produtoService.Update(modelProduto);
        }

        public void Remove(Guid id)
        {
            _produtoService.Remove(id);
        }

        public ProdutoViewModel GetById(Guid id)
        {
            var modelProduto = _produtoService.GetById(id);
            return _mapper.Map<ProdutoViewModel>(modelProduto);
        }

        public IList<ProdutoViewModel> GetAll()
        {
            var modelProdutos = _produtoService.GetAll();
            return _mapper.Map<IList<ProdutoViewModel>>(modelProdutos);
        }

        public IList<ProdutoViewModel> Find(Func<Produto, bool> predicate)
        {
            var modelProdutos = _produtoService.Find(predicate);
            return _mapper.Map<IList<ProdutoViewModel>>(modelProdutos);
        }
    }
}