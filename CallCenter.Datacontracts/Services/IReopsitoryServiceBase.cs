using System.Collections.Generic;
using System.ServiceModel;
using CallCenter.Server.Helper;

namespace CallCenter.ServiceContracts.Services
{
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
    public interface IReopsitoryServiceBase<T>
    {
        [OperationContract]
        void DeleteById(int id);
        [OperationContract]
        IEnumerable<T> GetAll();
        [OperationContract]
        T GetById(int id);
        [OperationContract]
        IEnumerable<T> GetByName(string entityName);
        [OperationContract]
        int Insert(T entity);
    }
}