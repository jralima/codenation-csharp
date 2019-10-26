using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AceleraDevBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: api/cliente
        [HttpGet]
        public IEnumerable<ClienteViewModel> Get()
        {
            _clienteAppService.Add(new ClienteViewModel { Nome = "Lacerda", Sobrenome = "Lima", Cpf="1234567890" });
            return _clienteAppService.GetAll();
        }

    }
}