using System;
using CallCenter.Common.Entities;

namespace CallCenter.Common.DataContracts
{
    public interface IOperatorChatMessage:IIdentifier, ISerializable
    {
        DateTime Date { get; set; }
        string Message { get; set; }
        ChatMessageType MessageType { get; set; }
    }
}