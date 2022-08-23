using Homework04.Models.Controller;
using Homework04.Models.Repository;
using Homework04.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Homework04.Services
{
    public class UserService : IService<UserDto>
    {
        private readonly IRepository<User> _repository;

        private static User Map(UserDto user)
        {
            return user == null ? null : new()
            {
                Comment = user.Comment,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Id = user.Id,
                IsDeleted = user.IsDeleted,
                MiddleName = user.MiddleName
            };
        }

        private static UserDto Map(User user)
        {
            return user == null ? null : new()
            {
                Comment = user.Comment,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Id = user.Id,
                IsDeleted = user.IsDeleted,
                MiddleName = user.MiddleName
            };
        }

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public bool Add(UserDto entity) => _repository.Add(Map(entity));

        public bool Delete(int id) => _repository.Delete(id);

        public bool Delete(UserDto entity) => _repository.Delete(Map(entity));

        public UserDto Get(int id) => Map(_repository.Get(id));

        public IEnumerable<UserDto> Get(int skip, int take) => _repository.Get(skip, take).Select(p => Map(p));

        public IEnumerable<UserDto> Search(string term) => _repository.Search(term).Select(p => Map(p));

        public bool Update(UserDto entity) => _repository.Update(entity.Id, Map(entity));
    }
}
