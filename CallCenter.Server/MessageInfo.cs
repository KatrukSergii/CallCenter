using System;
using CallCenter.Common;

namespace CallCenter.Server
{
    public class MessageInfo : IMessageInfo
    {

        public MessageInfo(int fromId, int toId)
        {
            if(fromId < 0)
                throw new ArgumentException();

            if (toId < 0)
                throw new ArgumentException();

            this.FromId = fromId;
            this.ToId = toId;
        }
        public int FromId { get; set; }
        public int ToId { get; set; }
    }
}