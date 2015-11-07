using System;
using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class ChatAction : IChatAction
    {
        public virtual int Id { get; set; }
        public virtual IChat Chat { get; set; }
        public virtual DateTime ActionDate { get; set; }
        public virtual ChatActionType ActionType { get; set; }
        public virtual IOperator InvokeOperator { get; set; }
    }
}