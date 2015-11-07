using System;
using System.Security.Principal;

namespace CallCenter.ServiceContracts.DataContracts
{
    public interface IOperatorChatMessage:IIdentity
    {
        DateTime Date { get; set; }
        string Message { get; set; }
        ChatMessageType MessageType { get; set; }
    }
}