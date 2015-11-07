using System.Collections.Generic;

namespace CallCenter.ServiceContracts.DataContracts
{
    public interface IOperatorChatHistory
    {
        IEnumerable<IOperatorChat> Chats { get; set; } 
    }
}