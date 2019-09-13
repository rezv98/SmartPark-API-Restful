using System.Collections.Generic;
namespace Parking.Repository
{
    public interface IRepository<T>
    {
         
        bool  Save(T entity);
        bool  Update(T entity);
        bool  Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}