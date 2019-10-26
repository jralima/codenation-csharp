using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AceleraDevBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAppService _pedidoAppService;
        public PedidoController(IPedidoAppService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        // GET: api/produto
        [HttpGet]
        public IEnumerable<PedidoViewModel> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                _pedidoAppService.Add(new PedidoViewModel { Numero = i });
            }

            return _pedidoAppService.GetAll();
        }
    }
}