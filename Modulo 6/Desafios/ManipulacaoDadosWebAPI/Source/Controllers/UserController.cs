using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET api/user
        [HttpGet("{accelerationName}?/{companyId}?")]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            /*
            Quando não informados ou quando ambos informados, deve retornar status 204
             - parâmetro accelerationName: deve apontar para o método FindByAccelerationName e retornar uma lista de UserDTO
             - parâmetro companyId: deve apontar para o método FindByCompanyId e retornar uma lista de UserDTO
                */
            if ((accelerationName != default && companyId != default))
                return NoContent();

            if (accelerationName != default)
            {
                var accelerations = service.FindByAccelerationName(accelerationName);

                if (accelerationName != default)
                {
                    var listUserDTO = mapper.Map<UserDTO>(accelerations);
                    return Ok(listUserDTO);
                }
                return NoContent();
            }

            if (companyId != default)
            {
                var accelerations = service.FindByCompanyId(companyId.Value);

                if (accelerationName != default)
                {
                    var listUserDTO = mapper.Map<UserDTO>(accelerations);
                    return Ok(listUserDTO);
                }
            }

            return NoContent();
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            //deve apontar para o método FindById e retornar um UserDTO
            if (id != default)
            {
                var user = service.FindByCompanyId(id);

                if (user != default)
                {
                    var listUserDTO = mapper.Map<UserDTO>(user);
                    return Ok(listUserDTO);
                }
            }

            return NoContent();
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            // deve receber um UserDTO, apontar para o método Save e retornar um UserDTO
            if (value != default)
            {
                var user = mapper.Map<User>(value);
                user = service.Save(user);
                var listUserDTO = mapper.Map<UserDTO>(user);
                return Ok(listUserDTO);
            }

            return NoContent();
        }
    }
}
