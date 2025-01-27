﻿using AceleraDev.Domain.Models;
using AceleraDev.Data.Repositories.Base;
using System.Collections.Generic;
using AceleraDev.Domain.Repositories;
using AceleraDev.Data.Context;

namespace AceleraDev.Data.Repositories
{
    /// <summary>
    /// Classe Produto Repository
    /// </summary>
    public class ProdutoRepository: RepositoryBase<Produto>, IProdutoRepository{
        public ProdutoRepository(AceleraDevContext context) : base(context)
        {
            //base._mock = new List<Produto>
            //{
            //    new Produto
            //    {
            //        Descricao = "Produto",
            //        Valor = 25
            //    }
            //};
        }
    }
}
