using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
            //_clienteAppService.Add(new ClienteViewModel { Nome = "Lacerda", Sobrenome = "Lima", Cpf="1234567890" });
            return _clienteAppService.GetAll();
        }

        // GET: api/cliente/id
        [HttpGet("{id}")]
        public ClienteViewModel Get(Guid id)
        {
            return _clienteAppService.GetById(id);
        }

        // PUT: api/cliente/id
        [HttpPut]
        public void Update([FromBody()] ClienteViewModel cliente)
        {
            _clienteAppService.Update(cliente);
        }

        // POST: api/cliente/id
        [HttpPost]
        public void Add([FromBody()] ClienteViewModel cliente)
        {
            _clienteAppService.Add(cliente);
        }

        // DELETE: api/cliente/id
        [HttpDelete("{id}")]
        public void Remove(Guid id)
        {
            _clienteAppService.Remove(id);
        }
    }
}