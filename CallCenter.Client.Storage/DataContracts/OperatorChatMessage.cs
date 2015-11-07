using System;

namespace CallCenter.Common.DataContracts
{
    public class OperatorChatMessage : IOperatorChatMessage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public ChatMessageType MessageType { get; set; }
    }
}