using System.Collections.Generic;

namespace CallCenter.Common.Entities
{
    public interface IChat : IIdentifier
    {
        IEnumerable<IChatTopic> Topics { get; set; }
        IChatTopic CurrentTopic { get; }
        IEnumerable<IChatAction> ChatActions { get; set; } 
    }
}