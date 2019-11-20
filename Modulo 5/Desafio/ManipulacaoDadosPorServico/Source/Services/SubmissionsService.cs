using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _context.Set<Candidate>().
                    Where(candidate => candidate.AccelerationId == accelerationId).
                    Join(_context.Set<User>(),
                        candidate => candidate.UserId,
                        user => user.Id,
                        (candidate, user) => user).
                    Join(_context.Set<Submission>(),
                        user => user.Id,
                        submission => submission.UserId,
                        (user, submission) => submission).
                    Where(submission => submission.ChallengeId == challengeId).
                    Distinct().
                    ToList(); ;
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Set<Submission>().
                    Where(challenge => challenge.ChallengeId == challengeId).
                    Max(challenge => challenge.Score);
        }

        public Submission Save(Submission submission)
        {
            if (MustInclude(submission))
                _context.Set<Submission>().Add(submission);
            else
                _context.Set<Submission>().Update(submission);

            _context.SaveChanges();
            return submission;
        }

        private bool MustInclude(Submission submission)
        {
            var result = _context.Set<Submission>()
                .Where(p => p.UserId == submission.UserId && p.ChallengeId == submission.ChallengeId);
            return result.Count() == 0;
        }
    }
}
