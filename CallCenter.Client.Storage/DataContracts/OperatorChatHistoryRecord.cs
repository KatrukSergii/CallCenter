using System;
using System.Collections.Generic;

namespace CallCenter.Common.DataContracts
{
    public class OperatorChatHistoryRecord : IOperatorChatHistoryRecord
    {
        public DateTime CreateDate { get; set; }
        public string Topic { get; set; }
        public int ChatId { get; set; }
        public IEnumerable<IOperatorChatMessage> Messages { get; set; }
    }
}
