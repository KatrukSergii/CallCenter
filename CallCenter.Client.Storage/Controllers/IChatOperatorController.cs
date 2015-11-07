using System;
using System.Collections.Generic;
using CallCenter.Common.DataContracts;

namespace CallCenter.Common.Controllers
{
    public interface IChatOperatorController
    {
        IEnumerable<IOperatorChatHistoryRecord> GetHistoryByAgentId(int agentId, DateTime fromDate, int count = 0);
        IEnumerable<IOperatorChatMessage> GetMessagesByChatId(int chatId, DateTime fromDate, int count = 0);
    }
}