using System.Collections.Generic;

namespace CallCenter.Common.Entities
{
    public interface IChatActionParticipant:IIdentifier
    {
        IChatAction ChatAction { get; set; }
        IEnumerable<IOperator> Participants { get; } 
    }
}