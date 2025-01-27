﻿using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var obj = new QuoteView();
            var result = _service.GetAnyQuote();

            if (result == null)
                return new NotFoundResult();

            obj.Actor = result.Actor;
            obj.Detail = result.Detail;
            obj.Id = result.Id;

            return new ActionResult<QuoteView>(obj);

        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var obj = new QuoteView();
            var result = _service.GetAnyQuote(actor);

            if (result == null)
                return new NotFoundResult();

            obj.Actor = result.Actor;
            obj.Detail = result.Detail;
            obj.Id = result.Id;

            return new ActionResult<QuoteView>(obj);
        }

    }
}
