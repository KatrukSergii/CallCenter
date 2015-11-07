using System;
using System.Collections.Generic;
using System.ServiceModel;
using CallCenter.Common.DataContracts;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfServer.Proxies
{
    public class ChatServiceProxy : ClientBase<IChatService>, IChatService
    {
        public IEnumerable<IOperatorChatHistoryRecord> GetChatHistory(int agentId, DateTime fromDate, int count)
        {
            return this.Channel.GetChatHistory(agentId, fromDate, count);
        }

        public IEnumerable<IOperatorChatMessage> GetChatMessages(int chatId, DateTime fromDate, int count)
        {
            return this.Channel.GetChatMessages(chatId, fromDate, count);
        }
    }
}