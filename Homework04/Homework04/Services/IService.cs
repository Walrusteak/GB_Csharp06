using System.Collections.Generic;

namespace Homework04.Services
{
    public interface IService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Search(string term);
        IEnumerable<T> Get(int skip, int take);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        bool Delete(T entity);
    }
}
