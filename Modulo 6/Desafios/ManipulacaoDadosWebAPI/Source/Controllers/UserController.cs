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

        [HttpGet("{accelerationName}?/{companyId}?")]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            if ((accelerationName != default && companyId != default))
                return NoContent();

            if (accelerationName != default)
            {
                var accelerations = service.FindByAccelerationName(accelerationName).
                    Select(x => mapper.Map<UserDTO>(x)).
                    ToList();

                return Ok(accelerations);
            }

            if (companyId != default)
            {
                var accelerations = service.FindByCompanyId(companyId.Value).
                    Select(x => mapper.Map<UserDTO>(x)).
                    ToList();

                return Ok(accelerations);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = mapper.Map<UserDTO>(service.FindById(id));
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
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
