using Homework04.Models.Controller;
using Homework04.Models.Repository;
using Homework04.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Homework04.Services
{
    public class EmployeeService : IService<EmployeeDto>
    {
        private readonly IRepository<Employee> _repository;

        private static Employee Map(EmployeeDto employee)
        {
            return employee == null ? null : new()
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Id = employee.Id,
                IsDeleted = employee.IsDeleted,
                Age = employee.Age,
                Company = employee.Company,
                Email = employee.Email
            };
        }

        private static EmployeeDto Map(Employee employee)
        {
            return employee == null ? null : new()
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Id = employee.Id,
                IsDeleted = employee.IsDeleted,
                Age = employee.Age,
                Company = employee.Company,
                Email = employee.Email
            };
        }

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public bool Add(EmployeeDto entity) => _repository.Add(Map(entity));

        public bool Delete(int id) => _repository.Delete(id);

        public bool Delete(EmployeeDto entity) => _repository.Delete(Map(entity));

        public EmployeeDto Get(int id) => Map(_repository.Get(id));

        public IEnumerable<EmployeeDto> Get(int skip, int take) => _repository.Get(skip, take).Select(p => Map(p));

        public IEnumerable<EmployeeDto> Search(string term) => _repository.Search(term).Select(p => Map(p));

        public bool Update(EmployeeDto entity) => _repository.Update(entity.Id, Map(entity));
    }
}
