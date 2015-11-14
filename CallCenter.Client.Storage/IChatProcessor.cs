using System;
using System.Collections.Generic;
using CallCenter.Common.DataContracts;

namespace CallCenter.Common
{
    public interface IChatProcessor
    {
        IEnumerable<IOperatorChatHistoryRecord> GetChatHistory(int agentId, DateTime fromDate, int count);
    }
}