using System.ServiceModel;
using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;

namespace CallCenter.ServiceContracts.Services
{
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
    public interface IOperatorEventProcessorService
    {

        [OperationContract]
        IOperator ChangeOperatorState(IOperatorEventInfo eventInfo);
    }
}
