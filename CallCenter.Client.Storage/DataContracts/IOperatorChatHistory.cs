using System.Collections.Generic;

namespace CallCenter.Common.DataContracts
{
    public interface IOperatorChatHistory
    {
        IEnumerable<IOperatorChatHistory> ChatHistory { get; set; } 
    }
}