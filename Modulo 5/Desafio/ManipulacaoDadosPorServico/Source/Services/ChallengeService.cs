using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context.Set<User>().
                    Where(user => user.Id == userId).
                    Join(_context.Set<Candidate>(),
                        user => user.Id,
                        candidate => candidate.UserId,
                        (user, candidate) => candidate).
                    Join(_context.Set<Acceleration>(),
                        candidate => candidate.AccelerationId,
                        acceleration => acceleration.Id,
                        (candidate, acceleration) => acceleration).
                    Where(acceleration => acceleration.Id == accelerationId).
                    Join(_context.Set<Models.Challenge>(),
                        acceleration => acceleration.ChallengeId,
                        challenge => challenge.Id,
                        (acceleration, challenge) => challenge).
                    Distinct().
                    ToList(); ;
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (MustInclude(challenge))
                _context.Set<Models.Challenge>().Add(challenge);
            else
                _context.Set<Models.Challenge>().Update(challenge);

            _context.SaveChanges();
            return challenge;
        }

        private bool MustInclude(Models.Challenge challeng)
        {
            var result = _context.Set<Models.Challenge>()
                .Where(p => p.Id == challeng.Id);
            return result.Count() == 0;
        }
    }
}