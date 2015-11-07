using System;
using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class ChatTopic:IChatTopic
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Topic { get; set; }
        public virtual IChat Chat { get; set; }
    }
}