using System.Collections.Generic;
using System.ServiceModel;
using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;
using CallCenter.ServiceContracts;

namespace CallCenter.WcfService
{
    public class LoginService : ILoginService
    {
        public IOperator Login(string number)
        {
            IControllerFactory controllerFactory = Resolver.Resolve<IControllerFactory>();
            return controllerFactory.OperatorsController.GetByNumber(number);
        }

        public void LogOut(string number)
        {
            
        }
    }

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
