using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.CrossCutting.Constants;
using AceleraDevBase.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AceleraDevBase.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IUsuarioAppService usuarioAppService;

        public ClienteController(IClienteAppService clienteAppService, IUsuarioAppService usuarioAppService)
            : base(usuarioAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: api/cliente
        [HttpGet]
        public ActionResult Get()
        {
            //var end = new EnderecoViewModel
            //{
            //    Cep = "88058580",
            //    Rua = "Rua Abel",
            //    Numero = 503

            //};
            //var endDois = new EnderecoViewModel
            //{
            //    Cep = "88058580",
            //    Rua = "Rua Teste",
            //    Numero = 503

            //};

            //var clienteUm = new ClienteViewModel
            //{
            //    Nome = "Lacerda",
            //    Sobrenome = "Junior 5",
            //    Cpf = "08404568758",
            //    DataNascimento = new DateTime(1981, 04, 16),
            //    //Enderecos = new List<EnderecoViewModel> { end, endDois }
            //};

            //_clienteAppService.Add(clienteUm);

            //_clienteAppService.Add(new ClienteViewModel { Nome = "Lacerda", Sobrenome = "Lima", Cpf="1234567890" });
            try
            {
                var clientes = _clienteAppService.GetAll();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = @$"Ocorreu um erro ao buscar os clientes.
                    \nErro: {ex.Message}"
                });
            }


            //return _clienteAppService.BuscarTop10();
        }

        // GET: api/cliente/id
        [HttpGet("{id}")]
        public ActionResult<ClienteViewModel> Get(Guid id)
        {
            try
            {
                var cliente = _clienteAppService.GetById(id);

                if (cliente != default)
                    return Ok(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"Ocorreu um erro ao buscar o cliente de código: {id}." +
                    $"\nErro: {ex.Message}"
                });
            }

        }

        // GET: api/cliente/id/enderecos/idEndereco?
        // este ? indica que o param é opcional
        [HttpGet("{id}/enderecos/{idEndereco?}")]
        public ActionResult<ClienteViewModel> GetEnderecosCliente(Guid id, Guid idEndereco)
        {
            try
            {
                var cliente = _clienteAppService.GetById(id);

                if (cliente != default)
                    return Ok(cliente.Enderecos);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"Ocorreu um erro ao buscar os endereços do cliente de código: {id}." +
                    $"\nErro: {ex.Message}"
                });
            }

        }

        // PUT: api/cliente/id
        [HttpPut("{id}")]
        public ActionResult Update([FromQuery()] Guid id, [FromBody()] ClienteViewModel cliente)
        {
            if (id != cliente.Id)
                return BadRequest();
            try
            {
                _clienteAppService.Update(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"Ocorreu um erro ao alterar cliente de código: {id}." +
                    $"\nErro: {ex.Message}"
                });
            }
        }

        // POST: api/cliente/id
        [HttpPost]
        //public ActionResult Add([FromHeader] [Required(ErrorMessage = "Obrigatório informar a empresa no header")] string empresa, [FromBody()] ClienteViewModel cliente)
        public ActionResult Add([FromBody()] ClienteViewModel cliente)
        {
            try
            {
                cliente = _clienteAppService.Add(cliente);

                return Created($"{Request.Path.Value}/{cliente.Id}", cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"Ocorreu um erro ao incluir cliente de código: {cliente.Id}." +
                    $"\nErro: {ex.Message}"
                });
            }
        }

        // DELETE: api/cliente/id
        [Authorize(Roles = Constants.PERFIL_ADMIN)]
        [HttpDelete("{id}")]
        public ActionResult Remove([FromQuery()] Guid id)
        {
            try
            {
                _clienteAppService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"Ocorreu um erro ao excluir cliente de código: {id}." +
                    $"\nErro: {ex.Message}"
                });
            }
        }
    }
}