using System.Collections.Generic;

namespace Homework03.Services
{
    public interface IService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Search(string term);
        IEnumerable<T> Get(int skip, int take);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
    }
}
