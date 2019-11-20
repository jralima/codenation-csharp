using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Set<Candidate>().Where(p => p.AccelerationId == accelerationId).ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates.Where(p => p.CompanyId == companyId).ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Set<Candidate>().Where(p => p.UserId == userId && p.AccelerationId == accelerationId && p.CompanyId == companyId).FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            if (MustInclude(candidate))
                _context.Set<Candidate>().Add(candidate);
            else
                _context.Update<Candidate>(candidate);

            _context.SaveChanges();
            return candidate;
        }

        private bool MustInclude(Candidate candidate)
        {
            var obj = _context.Set<Candidate>()
                .Where(p => p.UserId == candidate.UserId && p.AccelerationId == candidate.AccelerationId && p.CompanyId == candidate.CompanyId);

            /*
             Erro: 
             The instance of entity type 'candidate' cannot be tracked because another instance with the same key value for {'UserId, AccelerationId, CompanyId'} is already being tracked. 
             When attaching existing entities, ensure that only one entity instance with a given key value is attached.
             
             */
            // var obj  = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

            return (obj.Count() == 0);
        }
    }
}
