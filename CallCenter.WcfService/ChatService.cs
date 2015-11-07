using System;
using System.Collections.Generic;
using System.ServiceModel;
using CallCenter.Common.Controllers;
using CallCenter.Common.DataContracts;
using CallCenter.Server.Helper;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfService
{
    public class ChatService:IChatService
    {
        public IEnumerable<IOperatorChatHistoryRecord> GetChatHistory(int agentId, DateTime fromDate, int count)
        {
            IControllerFactory controllerFactory = Resolver.Resolve<IControllerFactory>();
            return controllerFactory.ChatOperatorController.GetHistoryByAgentId(agentId, fromDate, count);
        }

        public IEnumerable<IOperatorChatMessage> GetChatMessages(int chatId, DateTime fromDate, int count)
        {
            throw new NotImplementedException();
        }
    }
}