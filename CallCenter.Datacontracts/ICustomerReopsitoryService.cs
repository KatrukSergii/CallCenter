using System.Collections.Generic;
using System.ServiceModel;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;

namespace CallCenter.ServiceContracts
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

    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
    public interface IOperatorRepositoryService : IReopsitoryServiceBase<IOperator>
    {
        [OperationContract]
        IOperator GetByNumber(string number);
    }
}