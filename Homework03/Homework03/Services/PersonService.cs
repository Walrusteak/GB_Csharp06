using Homework03.Models.Controller;
using Homework03.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Homework03.Services
{
    public class PersonService : IService<Person>
    {
        private readonly IRepository<Models.Repository.Person> _repository;

        private static Models.Repository.Person Map(Person person)
        {
            return new()
            {
                Age = person.Age,
                Company = person.Company,
                Email = person.Email,
                FirstName = person.FirstName,
                Id = person.Id,
                LastName = person.LastName
            };
        }

        private static Person Map(Models.Repository.Person person)
        {
            return new()
            {
                Age = person.Age,
                Company = person.Company,
                Email = person.Email,
                FirstName = person.FirstName,
                Id = person.Id,
                LastName = person.LastName
            };
        }

        public PersonService(IRepository<Models.Repository.Person> repository)
        {
            _repository = repository;
        }

        public void Add(Person entity) => _repository.Add(Map(entity));

        public void Delete(int id) => _repository.Delete(id);

        public void Delete(Person entity) => _repository.Delete(Map(entity));

        public Person Get(int id) => Map(_repository.Get(id));

        public IEnumerable<Person> Get(int skip, int take) => _repository.Get(skip, take).Select(p => Map(p));

        public IEnumerable<Person> Search(string term) => _repository.Search(term).Select(p => Map(p));

        public void Update(Person entity) => _repository.Update(entity.Id, Map(entity));
    }
}
