using System;
using CallCenter.Common;

namespace CallCenter.Server
{
    public class Message : IMessage
    {

        public Message(string text, IMessageInfo messageInfo)
        {
            if(messageInfo == null)
                throw new ArgumentNullException("messageInfo");
            this.Text = text;
            this.MessageInfo = messageInfo;
        }
        public string Text { get; set; }
        public IMessageInfo MessageInfo { get; set; }
    }
}