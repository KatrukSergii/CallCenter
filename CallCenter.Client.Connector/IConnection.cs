using CallCenter.Common;
using CallCenter.Common.Controllers;
using CallCenter.ServiceContracts;

namespace CallCenter.Client.Communication
{
    public interface IConnection
    {
        void Connect();
        void Disconncet();
        ILoginService LoginService { get; set; }
        ICustomerController CustomerRepository { get; set; }
    }
}