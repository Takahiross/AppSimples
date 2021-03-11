using System.Collections.Generic;

namespace AppSimples.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ListSeries();
        T ReturnByID(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextID();
    }
}