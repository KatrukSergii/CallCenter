using CallCenter.Common;

namespace CallCenter.Server
{
    public class MessageInfo : IMessageInfo
    {

        public MessageInfo(int fromId, int toId)
        {
            this.FromId = fromId;
            this.ToId = toId;
        }
        public int FromId { get; set; }
        public int ToId { get; set; }
    }
}