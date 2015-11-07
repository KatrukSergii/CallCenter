using System;

namespace CallCenter.Common.Entities
{
    public interface IChatAction : IIdentifier
    {
        IChat Chat { get; set; }
        DateTime ActionDate { get; set; }
        ChatActionType ActionType { get; set; }
        IOperator InvokeOperator { get; set; }
    }
}