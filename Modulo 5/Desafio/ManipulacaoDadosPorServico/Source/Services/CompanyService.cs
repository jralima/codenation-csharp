using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Set<Acceleration>().
                    Where(acceleration => acceleration.Id == accelerationId).
                    Join(_context.Set<Candidate>(),
                        acceleration => acceleration.Id,
                        candidate => candidate.AccelerationId,
                        (acceleration, candidate) => candidate).
                    Join(_context.Set<Company>(),
                        candidate => candidate.CompanyId,
                        company => company.Id,
                        (candidate, company) => company).
                    Distinct().
                    ToList(); ;
        }

        public Company FindById(int id)
        {
            return _context.Set<Company>().FirstOrDefault(p => p.Id == id);
        }

        public IList<Company> FindByUserId(int userId)
        {

            return _context.Set<User>().
                    Where(user => user.Id == userId).
                    Join(_context.Set<Candidate>(),
                        user => user.Id,
                        candidate => candidate.UserId,
                        (user, candidate) => candidate).
                    Join(_context.Set<Company>(),
                        candidate => candidate.CompanyId,
                        company => company.Id,
                        (candidate, company) => company).
                    Distinct().
                    ToList();
        }

        public IList<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public void Remove(int id)
        {
            var obj = FindById(id);

            _context.Companies.Remove(obj);
            _context.SaveChanges();
        }

        public Company Save(Company company)
        {
            var obj = _context.Set<Company>().Where(p => p.Id == company.Id);

            if (obj == null)
                _context.Companies.Add(company);
            else
                _context.Companies.Update(company);

            _context.SaveChanges();
            return company;
        }
    }
}