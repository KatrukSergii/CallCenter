using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CallCenter.Client.SqlStorage.Entities;
using CallCenter.Common.DataContracts;
using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class ChatOperatorController : IChatOperatorController
    {
        private readonly ISessionFactory sessionFactory;

        public ChatOperatorController(ISessionFactory sessionFactory)
        {
            if(sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");
            this.sessionFactory = sessionFactory;
        }
        public IEnumerable<IOperatorChatHistoryRecord> GetHistoryByAgentId(int agentId, DateTime fromDate, int count)
        {
            try
            {
                using (ISession session = this.sessionFactory.OpenSession())
                {
                    IEnumerable<ChatAction> chatActions =
                        session.CreateCriteria<ChatAction>()
                            .List<ChatAction>()
                            .Where(
                                action =>
                                    action.ActionType == ChatActionType.Create && action.InvokeOperator.Id == agentId);
                    List<OperatorChatHistoryRecord> records = (from act in chatActions
                        select
                            new OperatorChatHistoryRecord
                            {
                                CreateDate = act.ActionDate,
                                ChatId = act.Chat.Id,
                                Topic = act.Chat.CurrentTopic.Topic
                            }).ToList();
                    int j = 9;
                    foreach (OperatorChatHistoryRecord operatorChatHistoryRecord in records)
                    {
                        List<OperatorChatMessage> messages = new List<OperatorChatMessage>();
                        for (int i = 0; i < 10; i++)
                        {
                            messages.Add(new OperatorChatMessage
                            {
                                Date = DateTime.Now.AddHours(i),
                                Id = i,
                                MessageType = ChatMessageType.Message,
                                Message = "Message" + i + j
                            });
                        }
                        operatorChatHistoryRecord.Messages = messages;
                        j++;
                    }

                    return records;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            return null;
        }

        public IEnumerable<IOperatorChatMessage> GetMessagesByChatId(int chatId, DateTime fromDate,
            int count = 0)
        {
            throw new NotImplementedException();
        }
    }
}