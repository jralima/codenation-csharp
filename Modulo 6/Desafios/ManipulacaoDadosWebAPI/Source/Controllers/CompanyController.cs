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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService service;
        private readonly IMapper mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{accelerationId}?/{userId}?")]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId != default && userId != default))
                return NoContent();

            if (accelerationId != default)
            {
                var accelerations = service.FindByAccelerationId(accelerationId.Value).
                    Select(x => mapper.Map<CompanyDTO>(x)).
                    ToList();
                return Ok(accelerations);
            }

            if (userId != default)
            {
                var accelerations = service.FindByUserId(userId.Value).
                    Select(x => mapper.Map<CompanyDTO>(x)).
                    ToList();
                return Ok(accelerations);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var obj = mapper.Map<CompanyDTO>(service.FindById(id));
            return Ok(obj);
        }

        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            if (value != default)
            {
                var obj = mapper.Map<Company>(value);
                obj = service.Save(obj);
                var listDTO = mapper.Map<CompanyDTO>(obj);
                return Ok(listDTO);
            }
            return NoContent();
        }
    }
}