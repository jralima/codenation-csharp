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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService service;
        private readonly IMapper mapper;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            if ((userId == default || accelerationId == default || companyId == default))
                return NoContent();

            var obj = mapper.Map<CandidateDTO>(service.FindById(userId, accelerationId, companyId));
            return Ok(obj);

        }

        [HttpGet("{accelerationId}?/{companyId}?")]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? accelerationId = null, int? companyId = null)
        {
            if ((accelerationId != default && companyId != default))
                return NoContent();

            if (accelerationId != default)
            {
                var accelerations = service.FindByAccelerationId(accelerationId.Value).
                Select(x => mapper.Map<CandidateDTO>(x)).
                ToList();
                return Ok(accelerations);
            }

            if (companyId != default)
            {
                var accelerations = service.FindByCompanyId(companyId.Value).
                Select(x => mapper.Map<CandidateDTO>(x)).
                ToList();
                return Ok(accelerations);
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            if (value != default)
            {
                var obj = mapper.Map<Candidate>(value);
                obj = service.Save(obj);
                var listDTO = mapper.Map<CandidateDTO>(obj);
                return Ok(listDTO);
            }

            return NoContent();
        }

    }
}
