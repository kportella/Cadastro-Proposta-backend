using System.Collections.Generic;

namespace Api.Orm.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        bool Add(T obj);
        void Remove(T obj);
        void Update(T obj);
    }
}
