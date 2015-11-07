using System;

namespace CallCenter.Common.Entities
{
    public interface IChatTopic : IIdentifier
    {
        DateTime Date { get; set; }
        string Topic { get; set; }
        IChat Chat { get; set; }
    }
}