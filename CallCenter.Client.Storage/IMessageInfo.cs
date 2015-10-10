namespace CallCenter.Common
{
    public interface IMessageInfo
    {
        int FromId { get; set; }
        int ToId { get; set; }
    }
}