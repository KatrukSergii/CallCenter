using System;
using System.Collections.Generic;

namespace CallCenter.ServiceContracts.DataContracts
{
    public interface IOperatorChat
    {
        IEnumerable<IOperatorChatMessage> Messages { get; }
        DateTime CreateDate { get; set; }
    }
}
