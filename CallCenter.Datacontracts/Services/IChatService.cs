using System;
using System.Collections.Generic;
using System.ServiceModel;
using CallCenter.Common.DataContracts;
using CallCenter.Server.Helper;

namespace CallCenter.ServiceContracts.Services
{
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
    public interface IChatService
    {
        [OperationContract]
        IEnumerable<IOperatorChatHistoryRecord> GetChatHistory(int agentId, DateTime fromDate, int count);
        IEnumerable<IOperatorChatMessage> GetChatMessages(int chatId, DateTime fromDate, int count);
    }
}
