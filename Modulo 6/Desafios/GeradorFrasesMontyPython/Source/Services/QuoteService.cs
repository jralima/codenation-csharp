using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            // "SELECT actor, detail FROM scripts WHERE type = 'Dialogue' AND actor IS NOT NULL ORDER BY RANDOM() LIMIT 1";
            var quotes = _context.Quotes.Where(x => x.Type == "Dialogue" && x.Actor != null).ToList();

            return quotes.
                OrderBy(x => _randomService.RandomInteger(quotes.Count)).
                FirstOrDefault();
        }

        public Quote GetAnyQuote(string actor)
        {
            // "SELECT actor, detail FROM scripts WHERE type = 'Dialogue' AND actor = ? ORDER BY RANDOM() LIMIT 1";
            var quotes = _context.Quotes.Where(x => x.Type == "Dialogue" && x.Actor == actor).ToList();
            return quotes.
                OrderBy(x => _randomService.RandomInteger(quotes.Count)).
                FirstOrDefault();
        }
    }
}