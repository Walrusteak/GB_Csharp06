using System.Collections.Generic;

namespace Homework03.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Search(string term);
        IEnumerable<T> Get(int skip, int take);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        void Delete(T entity);
    }
}
