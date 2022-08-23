using Homework04.Contexts;
using Homework04.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Homework04.Repositories
{
    internal sealed class UserRepository : IRepository<User>
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public bool Add(User entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id) => Delete(_context.Users.Find(id));

        public bool Delete(User entity)
        {
            try
            {
                entity.IsDeleted = true;
                return Commit();
            }
            catch
            {
                return false;
            }
        }

        public User Get(int id)
        {
            try
            {
                return _context.Users.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<User> Get(int skip, int take)
        {
            try
            {
                return _context.Users.Skip(skip).Take(take).ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<User> Search(string term)
        {
            try
            {
                return _context.Users.Where(u => u.FirstName.Contains(term) || u.LastName.Contains(term)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool Update(int id, User entity)
        {
            try
            {
                return Commit();
            }
            catch
            {
                return false;
            }
        }

        private bool Commit()
        {
            int count = _context.SaveChanges();
            return count > 0;
        }
    }
}
