using System.Collections.Generic;
using CallCenter.Common.Controllers;
using CallCenter.ServiceContracts;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfService
{
    public class RepositoryServiceBase<T> : IReopsitoryServiceBase<T>
    {
        private readonly IControllerFactory controllerFactory;
        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetByName(string entityName)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}