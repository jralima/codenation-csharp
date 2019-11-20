using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;
        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {

            return _context.Set<Company>().
                    Where(company => company.Id == companyId).
                    Join(_context.Set<Candidate>(),
                        company => company.Id,
                        candidate => candidate.CompanyId,
                        (company, candidate) => candidate).
                    Join(_context.Set<Acceleration>(),
                        candidate => candidate.AccelerationId,
                        acceleration => acceleration.Id,
                        (candidate, acceleration) => acceleration).
                    Distinct().
                    ToList(); ;
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations.FirstOrDefault(p => p.Id == id);
        }

        public IList<Acceleration> GetAll()
        {
            return _context.Accelerations.ToList();
        }
        public Acceleration Save(Acceleration acceleration)
        {
            if (MustInclude(acceleration))
                _context.Set<Acceleration>().Add(acceleration);
            else
                _context.Set<Acceleration>().Update(acceleration);

            _context.SaveChanges();
            return acceleration;
        }

        private bool MustInclude(Acceleration acceleration)
        {
            var result = _context.Set<Models.Acceleration>()
                .Where(p => p.Id == acceleration.Id);
            return result.Count() == 0;
        }
    }
}
