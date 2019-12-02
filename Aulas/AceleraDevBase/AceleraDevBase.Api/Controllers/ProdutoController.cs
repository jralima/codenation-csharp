using System.Collections.Generic;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AceleraDevBase.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        // GET: api/produto
        [HttpGet]
        public IEnumerable<ProdutoViewModel> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                _produtoAppService.Add(new ProdutoViewModel { Descricao = $"Produto {i}", Valor = i+10 });
            }
                        
            return _produtoAppService.GetAll();
        }
    }
}