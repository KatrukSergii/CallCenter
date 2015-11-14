using System;
using System.Collections.Generic;
using CallCenter.Common;
using CallCenter.Common.DataContracts;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfService
{
    public class ChatService : ServiceBase, IChatService
    {
        public ChatService(IServerEventsProcessor serverEventsProcessor) : base(serverEventsProcessor)
        {
        }

        public IEnumerable<IOperatorChatHistoryRecord> GetChatHistory(int agentId, DateTime fromDate, int count)
        {
            return this.ServerEventsProcessor.ChatProcessor.GetChatHistory(agentId, fromDate, count);
        }
    }
}