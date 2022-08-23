using Homework04.Contexts;
using Homework04.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Homework04.Repositories
{
    internal sealed class EmployeeRepository : IRepository<Employee>
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public bool Add(Employee entity)
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

        public bool Delete(int id) => Delete(_context.Employees.Find(id));

        public bool Delete(Employee entity)
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

        public Employee Get(int id)
        {
            try
            {
                return _context.Employees.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Employee> Get(int skip, int take)
        {
            try
            {
                return _context.Employees.Skip(skip).Take(take).ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Employee> Search(string term)
        {
            try
            {
                return _context.Employees.Where(u => u.FirstName.Contains(term) || u.LastName.Contains(term)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool Update(int id, Employee entity)
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

