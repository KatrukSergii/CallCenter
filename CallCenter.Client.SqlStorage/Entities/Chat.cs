using System.Collections.Generic;
using System.Linq;
using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class Chat : IChat
    {
        public virtual int Id { get; set; }
        public virtual IEnumerable<IChatTopic> Topics { get; set; }
        public virtual IChatTopic CurrentTopic { get { return this.Topics.FirstOrDefault(); }}
        public virtual IEnumerable<IChatAction> ChatActions { get; set; }
    }
}