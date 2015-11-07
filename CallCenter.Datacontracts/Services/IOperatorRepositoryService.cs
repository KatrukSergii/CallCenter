using System.ServiceModel;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;

namespace CallCenter.ServiceContracts.Services
{
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
    public interface IOperatorRepositoryService : IReopsitoryServiceBase<IOperator>
    {
        [OperationContract]
        IOperator GetByNumber(string number);
    }

    public interface IChatController
    {
        
    }
}