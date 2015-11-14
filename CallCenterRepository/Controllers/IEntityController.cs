using System.Collections.Generic;

namespace CallCenterRepository.Controllers
{
    public interface IEntityController<T>
    {
        void DeleteById(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByName(string entityName);
        int Insert(T entity);
    }
}