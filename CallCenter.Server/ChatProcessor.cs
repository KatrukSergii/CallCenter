using System;
using System.Collections.Generic;
using CallCenter.Common;
using CallCenter.Common.DataContracts;
using CallCenterRepository.Controllers;

namespace CallCenter.Server
{
    public class ChatProcessor : ProcessorBase, IChatProcessor
    {
        public ChatProcessor(IControllerFactory controllerFactory) : base(controllerFactory)
        {
        }

        public IEnumerable<IOperatorChatHistoryRecord> GetChatHistory(int agentId, DateTime fromDate, int count)
        {
            return this.ControllerFactory.ChatOperatorController.GetHistoryByAgentId(agentId, fromDate, count);
        }
    }
}