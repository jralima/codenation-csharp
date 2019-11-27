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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService service;
        private readonly IMapper mapper;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var obj = mapper.Map<AccelerationDTO>(service.FindById(id));
            return Ok(obj);
        }

        [HttpGet("{companyId}?")]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == default)
                return NoContent();

            var accelerations = service.FindByCompanyId(companyId.Value).
                Select(x => mapper.Map<AccelerationDTO>(x)).
                ToList();
            return Ok(accelerations);
        }

        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            if (value != default)
            {
                var obj = mapper.Map<Acceleration>(value);
                obj = service.Save(obj);
                var listDTO = mapper.Map<AccelerationDTO>(obj);
                return Ok(listDTO);
            }

            return NoContent();
        }
    }
}
