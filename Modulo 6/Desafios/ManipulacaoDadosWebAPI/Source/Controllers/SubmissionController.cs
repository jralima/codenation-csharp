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
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService service;
        private readonly IMapper mapper;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{challengeId}?")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if (challengeId == default)
                return NoContent();

            var obj = service.FindHigherScoreByChallengeId(challengeId.Value);
            return Ok(obj);
        }

        [HttpGet("{challengeId}?/{accelerationId}?")]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if ((challengeId == default && accelerationId == default))
                return NoContent();

            var accelerations = service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value).
                Select(x => mapper.Map<SubmissionDTO>(x)).
                ToList();
            return Ok(accelerations);
        }

        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            if (value != default)
            {
                var obj = mapper.Map<Submission>(value);
                obj = service.Save(obj);
                var listDTO = mapper.Map<SubmissionDTO>(obj);
                return Ok(listDTO);
            }
            return NoContent();
        }
    }
}