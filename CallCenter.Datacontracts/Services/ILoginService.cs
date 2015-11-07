using System.ServiceModel;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;

namespace CallCenter.ServiceContracts.Services
{
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
    public interface ILoginService
    {

        [OperationContract]
        IOperator Login(string number);

        [OperationContract]
        void LogOut(string number);
    }
}
