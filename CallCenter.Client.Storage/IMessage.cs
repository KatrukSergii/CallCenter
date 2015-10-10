namespace CallCenter.Common
{
    public interface IMessage
    {
        string Text { get; set; }
        IMessageInfo MessageInfo { get; set; }
    }
}