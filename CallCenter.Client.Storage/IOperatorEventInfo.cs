namespace CallCenter.Common
{
    public interface IOperatorEventInfo
    {
        string OperatorNumber { get; set; }
        EventReason Reason { get; set; }
        IHostInfo HostInfo { get; set; }
    }
}