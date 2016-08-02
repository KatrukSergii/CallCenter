using CallCenter.Common.Controllers;

namespace CallCenter.Common
{
    public interface IOperatorService:IOperatorsController
    {
        void Login(IOperatorEventInfo eventInfo);
        void Logout(IOperatorEventInfo eventInfo);
        void SendMessage(IMessage message);
        event MessageReceivedDelegate MessageReceived;
    }
    public delegate void MessageReceivedDelegate(IMessage message);
}