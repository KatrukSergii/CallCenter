using System.Collections.Generic;
using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class ChatActionParticipant : IChatActionParticipant
    {
        public virtual int Id { get; set; }
        public virtual IChatAction ChatAction { get; set; }
        public virtual IEnumerable<IOperator> Participants { get; set; }
    }
}