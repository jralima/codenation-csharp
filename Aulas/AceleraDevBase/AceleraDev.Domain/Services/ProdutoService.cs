using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Repositories;
using AceleraDev.Domain.Repositories.Base;

namespace AceleraDev.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
        {
            public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
            {
                
            }

    }
}