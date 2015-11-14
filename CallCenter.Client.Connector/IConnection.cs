using CallCenter.ServiceContracts.Services;
using CallCenterRepository.Controllers;

namespace CallCenter.Client.Communication
{
    public interface IConnection
    {
        void Connect();
        void Disconncet();
        IOperatorEventProcessorService OperatorEventProcessorService { get; set; }
        ICustomerController CustomerRepository { get; set; }
        IChatService ChatService { get; }
    }
}