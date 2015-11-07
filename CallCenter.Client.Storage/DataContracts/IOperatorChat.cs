using System;
using System.Collections.Generic;
using CallCenter.Common.Entities;

namespace CallCenter.Common.DataContracts
{
    public interface IOperatorChatHistoryRecord: ISerializable
    {
        DateTime CreateDate { get; set; }
        string Topic { get; set; }
        int ChatId { get; set; }

        IEnumerable<IOperatorChatMessage> Messages { get; }
    }
}
