using CallCenter.Common;

namespace CallCenter.Server
{
    public class Message : IMessage
    {

        public Message(string text, IMessageInfo messageInfo)
        {
            this.Text = text;
            this.MessageInfo = messageInfo;
        }
        public string Text { get; set; }
        public IMessageInfo MessageInfo { get; set; }
    }
}