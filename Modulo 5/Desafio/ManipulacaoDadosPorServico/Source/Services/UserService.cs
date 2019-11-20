using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Set<Acceleration>().
                    Where(acceleration => acceleration.Name == name).
                    Join(_context.Set<Candidate>(),
                        acceleration => acceleration.Id,
                        candidate => candidate.AccelerationId,
                        (acceleration, candidate) => candidate).
                    Join(_context.Set<User>(),
                        candidate => candidate.UserId,
                        user => user.Id,
                        (candidate, user) => user).
                    Distinct().
                    ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context.Set<Company>().
                    Where(company => company.Id == companyId).
                    Join(_context.Set<Candidate>(),
                        company => company.Id,
                        candidate => candidate.CompanyId,
                        (company, candidate) => candidate).
                    Join(_context.Set<User>(),
                        candidate => candidate.UserId,
                        user => user.Id,
                        (candidate, user) => user).
                    Distinct().
                    ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Remove(int id)
        {
            var obj = FindById(id);

            _context.Users.Remove(obj);
            _context.SaveChanges();
        }

        public User Save(User user)
        {
            if (MustInclude(user))
                _context.Set<User>().Add(user);
            else
                _context.Set<User>().Update(user);

            _context.SaveChanges();
            return user;
        }

        private bool MustInclude(User user)
        {
            var result = _context.Set<User>()
                .Where(p => p.Id == user.Id);
            return result.Count() == 0;
        }
    }
}
