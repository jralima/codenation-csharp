using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService service;
        private readonly IMapper mapper;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{accelerationId}?/{userId}?")]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId == default && userId == default))
                return NoContent();

            var accelerations = service.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value).
                Select(x => mapper.Map<ChallengeDTO>(x)).
                ToList();

            return Ok(accelerations);
        }

        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (value != default)
            {
                var obj = mapper.Map<Codenation.Challenge.Models.Challenge>(value);
                obj = service.Save(obj);
                var listDTO = mapper.Map<ChallengeDTO>(obj);
                return Ok(listDTO);
            }
            return NoContent();
        }
    }
}